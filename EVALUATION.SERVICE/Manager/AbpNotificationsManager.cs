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
    public partial class AbpNotificationsManager
    {

        AbpNotificationsProvider _AbpNotificationsProvider;

        #region Singleton

        public AbpNotificationsManager() 
        { 
          _AbpNotificationsProvider = new AbpNotificationsProvider();
        }
        
        /*
        private static AbpNotificationsManager _instance;

        public static AbpNotificationsManager Instance
        {
            get { return _instance ?? (_instance = new AbpNotificationsManager()); }
        }
        */
        #endregion

        public async Task<BusinessResponse<AbpNotificationsDto>> GetAbpNotificationsById(object id)
        {
            return await _AbpNotificationsProvider.GetAbpNotificationsById(id);
        }
        public async Task<BusinessResponse<AbpNotificationsDto>> GetAbpNotificationsByCriteria(BusinessRequest<AbpNotificationsDto> request)
        {
            return await _AbpNotificationsProvider.GetAbpNotificationsByCriteria(request);
        }

        
        public async Task<BusinessResponse<AbpNotificationsDto>> SaveAbpNotifications(BusinessRequest<AbpNotificationsDto> request)
        {
            var response = new BusinessResponse<AbpNotificationsDto>();
            
            {
                TransactionQueueManager.BeginWork(request, response);                    

                try
                {
                    /*** Commencer la logique ici ***/                                                    

                    response = await _AbpNotificationsProvider.SaveAbpNotifications(request);

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

        public async Task<BusinessResponse<Boolean>> DeleteAbpNotifications(BusinessRequest<AbpNotificationsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            {
                    TransactionQueueManager.BeginWork(request, response);                    

                    try
                    {
                        /*** Commencer la logique ici ***/                                                    

                        response = await _AbpNotificationsProvider.DeleteAbpNotifications(request);

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

