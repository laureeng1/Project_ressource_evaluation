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
    public partial class AbpPermissionsManager
    {

        AbpPermissionsProvider _AbpPermissionsProvider;

        #region Singleton

        public AbpPermissionsManager() 
        { 
          _AbpPermissionsProvider = new AbpPermissionsProvider();
        }
        
        /*
        private static AbpPermissionsManager _instance;

        public static AbpPermissionsManager Instance
        {
            get { return _instance ?? (_instance = new AbpPermissionsManager()); }
        }
        */
        #endregion

        public async Task<BusinessResponse<AbpPermissionsDto>> GetAbpPermissionsById(object id)
        {
            return await _AbpPermissionsProvider.GetAbpPermissionsById(id);
        }
        public async Task<BusinessResponse<AbpPermissionsDto>> GetAbpPermissionsByCriteria(BusinessRequest<AbpPermissionsDto> request)
        {
            return await _AbpPermissionsProvider.GetAbpPermissionsByCriteria(request);
        }

        
        public async Task<BusinessResponse<AbpPermissionsDto>> SaveAbpPermissions(BusinessRequest<AbpPermissionsDto> request)
        {
            var response = new BusinessResponse<AbpPermissionsDto>();
            
            {
                TransactionQueueManager.BeginWork(request, response);                    

                try
                {
                    /*** Commencer la logique ici ***/                                                    

                    response = await _AbpPermissionsProvider.SaveAbpPermissions(request);

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

        public async Task<BusinessResponse<Boolean>> DeleteAbpPermissions(BusinessRequest<AbpPermissionsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            {
                    TransactionQueueManager.BeginWork(request, response);                    

                    try
                    {
                        /*** Commencer la logique ici ***/                                                    

                        response = await _AbpPermissionsProvider.DeleteAbpPermissions(request);

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

