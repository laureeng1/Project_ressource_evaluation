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
    public partial class AbpUserNotificationsManager
    {

        AbpUserNotificationsProvider _AbpUserNotificationsProvider;

        #region Singleton

        public AbpUserNotificationsManager() 
        { 
          _AbpUserNotificationsProvider = new AbpUserNotificationsProvider();
        }
        
        /*
        private static AbpUserNotificationsManager _instance;

        public static AbpUserNotificationsManager Instance
        {
            get { return _instance ?? (_instance = new AbpUserNotificationsManager()); }
        }
        */
        #endregion

        public async Task<BusinessResponse<AbpUserNotificationsDto>> GetAbpUserNotificationsById(object id)
        {
            return await _AbpUserNotificationsProvider.GetAbpUserNotificationsById(id);
        }
        public async Task<BusinessResponse<AbpUserNotificationsDto>> GetAbpUserNotificationsByCriteria(BusinessRequest<AbpUserNotificationsDto> request)
        {
            return await _AbpUserNotificationsProvider.GetAbpUserNotificationsByCriteria(request);
        }

        
        public async Task<BusinessResponse<AbpUserNotificationsDto>> SaveAbpUserNotifications(BusinessRequest<AbpUserNotificationsDto> request)
        {
            var response = new BusinessResponse<AbpUserNotificationsDto>();
            
            {
                TransactionQueueManager.BeginWork(request, response);                    

                try
                {
                    /*** Commencer la logique ici ***/                                                    

                    response = await _AbpUserNotificationsProvider.SaveAbpUserNotifications(request);

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

        public async Task<BusinessResponse<Boolean>> DeleteAbpUserNotifications(BusinessRequest<AbpUserNotificationsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            {
                    TransactionQueueManager.BeginWork(request, response);                    

                    try
                    {
                        /*** Commencer la logique ici ***/                                                    

                        response = await _AbpUserNotificationsProvider.DeleteAbpUserNotifications(request);

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

