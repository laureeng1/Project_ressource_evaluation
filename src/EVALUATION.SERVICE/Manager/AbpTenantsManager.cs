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
    public partial class AbpTenantsManager
    {

        AbpTenantsProvider _AbpTenantsProvider;

        #region Singleton

        public AbpTenantsManager() 
        { 
          _AbpTenantsProvider = new AbpTenantsProvider();
        }
        
        /*
        private static AbpTenantsManager _instance;

        public static AbpTenantsManager Instance
        {
            get { return _instance ?? (_instance = new AbpTenantsManager()); }
        }
        */
        #endregion

        public async Task<BusinessResponse<AbpTenantsDto>> GetAbpTenantsById(object id)
        {
            return await _AbpTenantsProvider.GetAbpTenantsById(id);
        }
        public async Task<BusinessResponse<AbpTenantsDto>> GetAbpTenantsByCriteria(BusinessRequest<AbpTenantsDto> request)
        {
            return await _AbpTenantsProvider.GetAbpTenantsByCriteria(request);
        }

        
        public async Task<BusinessResponse<AbpTenantsDto>> SaveAbpTenants(BusinessRequest<AbpTenantsDto> request)
        {
            var response = new BusinessResponse<AbpTenantsDto>();
            
            {
                TransactionQueueManager.BeginWork(request, response);                    

                try
                {
                    /*** Commencer la logique ici ***/                                                    

                    response = await _AbpTenantsProvider.SaveAbpTenants(request);

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

        public async Task<BusinessResponse<Boolean>> DeleteAbpTenants(BusinessRequest<AbpTenantsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            {
                    TransactionQueueManager.BeginWork(request, response);                    

                    try
                    {
                        /*** Commencer la logique ici ***/                                                    

                        response = await _AbpTenantsProvider.DeleteAbpTenants(request);

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

