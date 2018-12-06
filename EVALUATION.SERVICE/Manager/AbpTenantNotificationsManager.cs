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
    public partial class AbpTenantNotificationsManager
    {

        AbpTenantNotificationsProvider _AbpTenantNotificationsProvider;

        #region Singleton

        public AbpTenantNotificationsManager() 
        { 
          _AbpTenantNotificationsProvider = new AbpTenantNotificationsProvider();
        }
        
        /*
        private static AbpTenantNotificationsManager _instance;

        public static AbpTenantNotificationsManager Instance
        {
            get { return _instance ?? (_instance = new AbpTenantNotificationsManager()); }
        }
        */
        #endregion

        public async Task<BusinessResponse<AbpTenantNotificationsDto>> GetAbpTenantNotificationsById(object id)
        {
            return await _AbpTenantNotificationsProvider.GetAbpTenantNotificationsById(id);
        }
        public async Task<BusinessResponse<AbpTenantNotificationsDto>> GetAbpTenantNotificationsByCriteria(BusinessRequest<AbpTenantNotificationsDto> request)
        {
            return await _AbpTenantNotificationsProvider.GetAbpTenantNotificationsByCriteria(request);
        }

        
        public async Task<BusinessResponse<AbpTenantNotificationsDto>> SaveAbpTenantNotifications(BusinessRequest<AbpTenantNotificationsDto> request)
        {
            var response = new BusinessResponse<AbpTenantNotificationsDto>();
            
            {
                TransactionQueueManager.BeginWork(request, response);                    

                try
                {
                    /*** Commencer la logique ici ***/                                                    

                    response = await _AbpTenantNotificationsProvider.SaveAbpTenantNotifications(request);

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

        public async Task<BusinessResponse<Boolean>> DeleteAbpTenantNotifications(BusinessRequest<AbpTenantNotificationsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            {
                    TransactionQueueManager.BeginWork(request, response);                    

                    try
                    {
                        /*** Commencer la logique ici ***/                                                    

                        response = await _AbpTenantNotificationsProvider.DeleteAbpTenantNotifications(request);

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

