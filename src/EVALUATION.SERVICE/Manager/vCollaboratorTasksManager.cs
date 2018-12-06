using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVALUATION.DATA.Provider;
using EVALUATION.CORE.Dto;
using Admin.Common.Domain;
using Admin.Common.Enum;
using Admin.Common.Helper;

namespace EVALUATION.SERVICE.Manager
{
    public partial class vCollaboratorTasksManager
    {

        vCollaboratorTasksProvider _vCollaboratorTasksProvider;

        #region Singleton

        public vCollaboratorTasksManager() 
        { 
          _vCollaboratorTasksProvider = new vCollaboratorTasksProvider();
        }
        
        /*
        private static vCollaboratorTasksManager _instance;

        public static vCollaboratorTasksManager Instance
        {
            get { return _instance ?? (_instance = new vCollaboratorTasksManager()); }
        }
        */
        #endregion

        public async Task<BusinessResponse<vCollaboratorTasksDto>> GetvCollaboratorTasksById(object id)
        {
            return await _vCollaboratorTasksProvider.GetvCollaboratorTasksById(id);
        }
        public async Task<BusinessResponse<vCollaboratorTasksDto>> GetvCollaboratorTasksByCriteria(BusinessRequest<vCollaboratorTasksDto> request)
        {
            return await _vCollaboratorTasksProvider.GetvCollaboratorTasksByCriteria(request);
        }

        
        public async Task<BusinessResponse<vCollaboratorTasksDto>> SavevCollaboratorTasks(BusinessRequest<vCollaboratorTasksDto> request)
        {
            var response = new BusinessResponse<vCollaboratorTasksDto>();
            
            {
                TransactionQueueManager.BeginWork(request, response);                    

                try
                {
                    /*** Commencer la logique ici ***/                                                    

                    response = await _vCollaboratorTasksProvider.SavevCollaboratorTasks(request);

                    /*** Finir la logique ici ***/
                }
                catch (Exception ex)
                {
                    CustomException.Write(request, response, ex);                       
                }
                finally
                {
                    TransactionQueueManager.FinishWork(request, response);
                }
            }            

            return response;
        }     

        public async Task<BusinessResponse<Boolean>> DeletevCollaboratorTasks(BusinessRequest<vCollaboratorTasksDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            {
                    TransactionQueueManager.BeginWork(request, response);                    

                    try
                    {
                        /*** Commencer la logique ici ***/                                                    

                        response = await _vCollaboratorTasksProvider.DeletevCollaboratorTasks(request);

                        /*** Finir la logique ici ***/
                    }
                    catch (Exception ex)
                    {
                        CustomException.Write(request, response, ex);                       
                    }
                    finally
                    {
                        TransactionQueueManager.FinishWork(request, response);
                    }
            }            

            return response;
        }

        public async Task<BusinessResponse<vCollaboratorTasksDto>> GetvCollaboratorTasksByPeriod(BusinessRequest<vCollaboratorTasksDto> request)
        {

            //return await _vCollaboratorTasksProvider.GetvCollaboratorTasksByPeriod(request);
            /*** Commencer la logique ici ***/
            //foreach (var item in request.ItemsToSearch)
            //{
            //    item.InfoSearchDeadline = new InfoSearch<DateTime>()
            //    {
            //        Consider = true,
            //        OperatorToUse = OperatorEnum.LESSOREQUAL
            //    };

            //    item.InfoSearchDateStarted = new InfoSearch<DateTime>()
            //    {
            //        Consider = true,
            //        OperatorToUse = OperatorEnum.MOREOREQUAL
            //    };
            //}

            //if (request.ItemToSearch.DateStarted == null)
            //    request.ItemToSearch.DateStarted = new DateTime(1970,01,01);

            request.ItemToSearch.InfoSearchDeadline = new InfoSearch<DateTime>()
            {
                Consider = true,
                OperatorToUse = OperatorEnum.LESSOREQUAL,
                //Intervalle = request.ItemToSearch.DateStarted ? request.ItemToSearch.DateStarted : request.ItemToSearch.Deadline
            };

            //request.ItemToSearch.InfoSearchDateStarted = new InfoSearch<DateTime>()
            //{
            //    Consider = true,
            //    OperatorToUse = OperatorEnum.MOREOREQUAL
            //};

            return await _vCollaboratorTasksProvider.GetvCollaboratorTasksByCriteria(request);
        }



    }
}

