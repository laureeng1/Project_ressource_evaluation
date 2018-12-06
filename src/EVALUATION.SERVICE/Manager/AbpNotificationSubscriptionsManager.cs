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
    public partial class AbpNotificationSubscriptionsManager
    {

        AbpNotificationSubscriptionsProvider _AbpNotificationSubscriptionsProvider;

        #region Singleton

        public AbpNotificationSubscriptionsManager() 
        { 
          _AbpNotificationSubscriptionsProvider = new AbpNotificationSubscriptionsProvider();
        }
        
        /*
        private static AbpNotificationSubscriptionsManager _instance;

        public static AbpNotificationSubscriptionsManager Instance
        {
            get { return _instance ?? (_instance = new AbpNotificationSubscriptionsManager()); }
        }
        */
        #endregion

        public async Task<BusinessResponse<AbpNotificationSubscriptionsDto>> GetAbpNotificationSubscriptionsById(object id)
        {
            return await _AbpNotificationSubscriptionsProvider.GetAbpNotificationSubscriptionsById(id);
        }
        public async Task<BusinessResponse<AbpNotificationSubscriptionsDto>> GetAbpNotificationSubscriptionsByCriteria(BusinessRequest<AbpNotificationSubscriptionsDto> request)
        {
            return await _AbpNotificationSubscriptionsProvider.GetAbpNotificationSubscriptionsByCriteria(request);
        }

        
        public async Task<BusinessResponse<AbpNotificationSubscriptionsDto>> SaveAbpNotificationSubscriptions(BusinessRequest<AbpNotificationSubscriptionsDto> request)
        {
            var response = new BusinessResponse<AbpNotificationSubscriptionsDto>();
            
            {
                TransactionQueueManager.BeginWork(request, response);                    

                try
                {
                    /*** Commencer la logique ici ***/                                                    

                    response = await _AbpNotificationSubscriptionsProvider.SaveAbpNotificationSubscriptions(request);

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

        public async Task<BusinessResponse<Boolean>> DeleteAbpNotificationSubscriptions(BusinessRequest<AbpNotificationSubscriptionsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            {
                    TransactionQueueManager.BeginWork(request, response);                    

                    try
                    {
                        /*** Commencer la logique ici ***/                                                    

                        response = await _AbpNotificationSubscriptionsProvider.DeleteAbpNotificationSubscriptions(request);

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
    }
}

