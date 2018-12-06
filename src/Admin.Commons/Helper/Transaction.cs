using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Transactions;
using Admin.Common.Domain;

namespace Admin.Common.Helper
{
    public static class TransactionFactory
    {        
        public delegate ResponseBase MethodBase(RequestBase request);

        public static ResponseBase ApplyTransaction(RequestBase request, MethodBase method)
        {
            if (!request.CanApplyTransaction)
                return method(request);

            var transaction = Create();
            var response = new ResponseBase();
            try
            {
                using (transaction)
                {
                    response = method(request);
                    if (response.HasError)
                        throw new CustomException(request, response, false);
                    transaction.Complete();
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                response.HasError = true;
            }
            finally
            {
                transaction.Dispose();
            }

            return response;
        }

        public static TransactionScope Create()
        {
            return new TransactionScope(TransactionScopeOption.RequiresNew, 
                                             new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted, Timeout = TimeSpan.FromSeconds(0) },TransactionScopeAsyncFlowOption.Enabled);
        }
    }

    public static class TransactionQueueManager
    {
        /// <summary>
        /// Liste des files de toutes les transactions
        /// </summary>
        private static List<TransactionQueue> _queue = new List<TransactionQueue>();

        /// <summary>
        /// File d'une transaction
        /// </summary>
        class TransactionQueue
        {
            public TransactionScope Transaction { get; set; }
            public int ProcessId { get; set; }
            public int ProcessDeepth { get; set; }

            private void Terminate()
            {
                Transaction.Dispose();
                ProcessId = 0;
                ProcessDeepth = 0;
            }

            public void Rollback()
            {
                Terminate();
            }

            public void Commit()
            {
                Transaction.Complete();
                Terminate();
            }
        }

        private static TransactionQueue GetCurrentTransactionQueue()
        {
            var processId = Thread.CurrentThread.ManagedThreadId;
            return _queue.FirstOrDefault(c => c.ProcessId == processId); // Exception générée s'il existe plus d'une file
        }

        private static TransactionQueue GetCurrentTransactionQueueTest(int queue)
        {
            return _queue.FirstOrDefault(c => c.ProcessId == queue); // Exception générée s'il existe plus d'une file
        }

        private static void SetProcessDeepth()
        {
            if (IsTransactionStarted())
            {
                GetCurrentTransactionQueue().ProcessDeepth++;
            }           
        }

        private static void SetProcessDeepthTest(int queue)
        {
            if (IsTransactionStartedTest(queue))
            {
                GetCurrentTransactionQueueTest(queue).ProcessDeepth++;
            }
        }

        private static void DeleteProcessDeepth()
        {
            if (IsTransactionStarted())
            {
                GetCurrentTransactionQueue().ProcessDeepth--;
            }   
        }

        private static void DeleteProcessDeepthTest(int queue)
        {
            if (IsTransactionStartedTest(queue))
            {
                GetCurrentTransactionQueueTest(queue).ProcessDeepth--;
            }
        }

        private static void StartTransaction()
        {
            if (IsTransactionStarted())
                throw new Exception("Deux (2) transactions ne peuvent être gérées à la fois dans le même processus!");

            // Créer une file de transaction pour le processus en cours
            var queue = new TransactionQueue { ProcessId = Thread.CurrentThread.ManagedThreadId, ProcessDeepth = 1, Transaction = TransactionFactory.Create() };
            _queue.Add(queue);            
        }

        private static int StartTransactionTest(int oldQueue)
        {
            if (IsTransactionStartedTest(oldQueue))
                throw new Exception("Deux (2) transactions ne peuvent être gérées à la fois dans le même processus!");

            // Créer une file de transaction pour le processus en cours
            var queue = new TransactionQueue { ProcessId = Thread.CurrentThread.ManagedThreadId, ProcessDeepth = 1, Transaction = TransactionFactory.Create() };
            _queue.Add(queue);
            return queue.ProcessId;
        }

        private static bool IsTransactionStarted()
        {
            return GetCurrentTransactionQueue() != null;
        }

        private static bool IsTransactionStartedTest(int queue)
        {
            return GetCurrentTransactionQueueTest(queue) != null;
        }


        private static void KillCurrentTransaction()
        {
            
            if (!IsTransactionStarted()) return;
            var transactionQueue = GetCurrentTransactionQueue();
            if (transactionQueue != null)
                _queue.Remove(transactionQueue);
        }


        private static void KillCurrentTransactionTest(int queue)
        {
            _queue = _queue.Where(x => x.ProcessId != 0).ToList();
            if (!IsTransactionStartedTest(queue)) return;
            var transactionQueue = GetCurrentTransactionQueueTest(queue);
            if (transactionQueue != null)
                _queue.Remove(transactionQueue);
        }

        public static void BeginWork(RequestBase request, ResponseBase response)
        {
            //SetProcessDeepth();

            /*  if (!request.CanApplyTransaction || IsTransactionStarted()) return;
              StartTransaction();

              // On ne doit plus appliquer une autre transaction 
              request.CanApplyTransaction = false;*/


            SetProcessDeepthTest(request.TransactionQueue);
            int queue = 0;
            if (!request.CanApplyTransaction || IsTransactionStartedTest(request.TransactionQueue)) return;
            queue = StartTransactionTest(request.TransactionQueue);

            // On ne doit plus appliquer une autre transaction 
            request.CanApplyTransaction = false;
            request.TransactionQueue = queue;

        }

        public static void BeginWorkTest(RequestBase request, ResponseBase response)
        {
             SetProcessDeepthTest(request.TransactionQueue);
             int queue = 0;
             if (!request.CanApplyTransaction || IsTransactionStartedTest(request.TransactionQueue)) return;
             queue = StartTransactionTest(request.TransactionQueue);

             // On ne doit plus appliquer une autre transaction 
             request.CanApplyTransaction = false;
             request.TransactionQueue = queue;

            /*SetProcessDeepth();
            if (!request.CanApplyTransaction || IsTransactionStarted()) return;
            StartTransaction();

            // On ne doit plus appliquer une autre transaction 
            request.CanApplyTransaction = false;*/

        }

        public static void FinishWork(RequestBase request, ResponseBase response)
        {
            /*DeleteProcessDeepth();

           if (IsTransactionStarted() && GetCurrentTransactionQueue().ProcessDeepth == 0 && !response.HasError)
            {
                // transaction effectuée avec succès!
                var transactionQueue = GetCurrentTransactionQueue();
                if (transactionQueue != null)
                    transactionQueue.Commit();
                KillCurrentTransaction();
                return;
            }

            if (!IsTransactionStarted() || !response.HasError) return;
            // la transaction a échoué!
            var transactionQueueForRollback = GetCurrentTransactionQueue();
            if (transactionQueueForRollback != null)
                transactionQueueForRollback.Rollback();

            KillCurrentTransaction();*/

            DeleteProcessDeepthTest(request.TransactionQueue);

            if (IsTransactionStartedTest(request.TransactionQueue) && GetCurrentTransactionQueueTest(request.TransactionQueue).ProcessDeepth == 0 && !response.HasError)
            {
                // transaction effectuée avec succès!
                var transactionQueue = GetCurrentTransactionQueueTest(request.TransactionQueue);
                if (transactionQueue != null)
                    transactionQueue.Commit();
                KillCurrentTransactionTest(request.TransactionQueue);
                return;
            }

            if (!IsTransactionStartedTest(request.TransactionQueue) || !response.HasError) return;
            // la transaction a échoué!
            var transactionQueueForRollback = GetCurrentTransactionQueueTest(request.TransactionQueue);
            if (transactionQueueForRollback != null)
                transactionQueueForRollback.Rollback();
            KillCurrentTransactionTest(request.TransactionQueue);
        }


        public static void FinishWorkTest(RequestBase request, ResponseBase response)
        {
            DeleteProcessDeepthTest(request.TransactionQueue);

            if (IsTransactionStartedTest(request.TransactionQueue) && GetCurrentTransactionQueueTest(request.TransactionQueue).ProcessDeepth == 0 && !response.HasError)
            {
                // transaction effectuée avec succès!
                var transactionQueue = GetCurrentTransactionQueueTest(request.TransactionQueue);
                if (transactionQueue != null)
                    transactionQueue.Commit();
                KillCurrentTransactionTest(request.TransactionQueue);
                return;
            }

            if (!IsTransactionStartedTest(request.TransactionQueue) || !response.HasError) return;
            // la transaction a échoué!
            var transactionQueueForRollback = GetCurrentTransactionQueueTest(request.TransactionQueue);
            if (transactionQueueForRollback != null)
                transactionQueueForRollback.Rollback();
            KillCurrentTransactionTest(request.TransactionQueue);


           /* DeleteProcessDeepth();

            if (IsTransactionStarted() && GetCurrentTransactionQueue().ProcessDeepth == 0 && !response.HasError)
            {
                // transaction effectuée avec succès!
                var transactionQueue = GetCurrentTransactionQueue();
                if (transactionQueue != null)
                    transactionQueue.Commit();
                KillCurrentTransaction();
                return;
            }

            if (!IsTransactionStarted() || !response.HasError) return;
            // la transaction a échoué!
            var transactionQueueForRollback = GetCurrentTransactionQueue();
            if (transactionQueueForRollback != null)
                transactionQueueForRollback.Rollback();
            KillCurrentTransaction();*/
        }



    }
}
