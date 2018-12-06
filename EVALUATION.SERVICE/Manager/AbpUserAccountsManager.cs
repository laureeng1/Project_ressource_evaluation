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
    public partial class AbpUserAccountsManager
    {

        AbpUserAccountsProvider _AbpUserAccountsProvider;

        #region Singleton

        public AbpUserAccountsManager() 
        { 
          _AbpUserAccountsProvider = new AbpUserAccountsProvider();
        }
        
        /*
        private static AbpUserAccountsManager _instance;

        public static AbpUserAccountsManager Instance
        {
            get { return _instance ?? (_instance = new AbpUserAccountsManager()); }
        }
        */
        #endregion

        public async Task<BusinessResponse<AbpUserAccountsDto>> GetAbpUserAccountsById(object id)
        {
            return await _AbpUserAccountsProvider.GetAbpUserAccountsById(id);
        }
        public async Task<BusinessResponse<AbpUserAccountsDto>> GetAbpUserAccountsByCriteria(BusinessRequest<AbpUserAccountsDto> request)
        {
            return await _AbpUserAccountsProvider.GetAbpUserAccountsByCriteria(request);
        }

        
        public async Task<BusinessResponse<AbpUserAccountsDto>> SaveAbpUserAccounts(BusinessRequest<AbpUserAccountsDto> request)
        {
            var response = new BusinessResponse<AbpUserAccountsDto>();
            
            {
                TransactionQueueManager.BeginWork(request, response);                    

                try
                {
                    /*** Commencer la logique ici ***/                                                    

                    response = await _AbpUserAccountsProvider.SaveAbpUserAccounts(request);

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

        public async Task<BusinessResponse<Boolean>> DeleteAbpUserAccounts(BusinessRequest<AbpUserAccountsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            {
                    TransactionQueueManager.BeginWork(request, response);                    

                    try
                    {
                        /*** Commencer la logique ici ***/                                                    

                        response = await _AbpUserAccountsProvider.DeleteAbpUserAccounts(request);

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

