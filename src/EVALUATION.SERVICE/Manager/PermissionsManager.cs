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
    public partial class PermissionsManager
    {

        PermissionsProvider _PermissionsProvider;

        #region Singleton

        public PermissionsManager() 
        { 
          _PermissionsProvider = new PermissionsProvider();
        }
        
        /*
        private static PermissionsManager _instance;

        public static PermissionsManager Instance
        {
            get { return _instance ?? (_instance = new PermissionsManager()); }
        }
        */
        #endregion

        public async Task<BusinessResponse<PermissionsDto>> GetPermissionsById(object id)
        {
            return await _PermissionsProvider.GetPermissionsById(id);
        }
        public async Task<BusinessResponse<PermissionsDto>> GetPermissionsByCriteria(BusinessRequest<PermissionsDto> request)
        {
            return await _PermissionsProvider.GetPermissionsByCriteria(request);
        }

        
        public async Task<BusinessResponse<PermissionsDto>> SavePermissions(BusinessRequest<PermissionsDto> request)
        {
            var response = new BusinessResponse<PermissionsDto>();
            
            {
                TransactionQueueManager.BeginWork(request, response);                    

                try
                {
                    /*** Commencer la logique ici ***/                                                    

                    response = await _PermissionsProvider.SavePermissions(request);

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

        public async Task<BusinessResponse<Boolean>> DeletePermissions(BusinessRequest<PermissionsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            {
                    TransactionQueueManager.BeginWork(request, response);                    

                    try
                    {
                        /*** Commencer la logique ici ***/                                                    

                        response = await _PermissionsProvider.DeletePermissions(request);

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

