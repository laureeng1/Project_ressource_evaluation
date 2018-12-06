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
    public partial class AbpUserLoginAttemptsManager
    {

        AbpUserLoginAttemptsProvider _AbpUserLoginAttemptsProvider;

        #region Singleton

        public AbpUserLoginAttemptsManager() 
        { 
          _AbpUserLoginAttemptsProvider = new AbpUserLoginAttemptsProvider();
        }
        
        /*
        private static AbpUserLoginAttemptsManager _instance;

        public static AbpUserLoginAttemptsManager Instance
        {
            get { return _instance ?? (_instance = new AbpUserLoginAttemptsManager()); }
        }
        */
        #endregion

        public async Task<BusinessResponse<AbpUserLoginAttemptsDto>> GetAbpUserLoginAttemptsById(object id)
        {
            return await _AbpUserLoginAttemptsProvider.GetAbpUserLoginAttemptsById(id);
        }
        public async Task<BusinessResponse<AbpUserLoginAttemptsDto>> GetAbpUserLoginAttemptsByCriteria(BusinessRequest<AbpUserLoginAttemptsDto> request)
        {
            return await _AbpUserLoginAttemptsProvider.GetAbpUserLoginAttemptsByCriteria(request);
        }

        
        public async Task<BusinessResponse<AbpUserLoginAttemptsDto>> SaveAbpUserLoginAttempts(BusinessRequest<AbpUserLoginAttemptsDto> request)
        {
            var response = new BusinessResponse<AbpUserLoginAttemptsDto>();
            
            {
                TransactionQueueManager.BeginWork(request, response);                    

                try
                {
                    /*** Commencer la logique ici ***/                                                    

                    response = await _AbpUserLoginAttemptsProvider.SaveAbpUserLoginAttempts(request);

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

        public async Task<BusinessResponse<Boolean>> DeleteAbpUserLoginAttempts(BusinessRequest<AbpUserLoginAttemptsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            {
                    TransactionQueueManager.BeginWork(request, response);                    

                    try
                    {
                        /*** Commencer la logique ici ***/                                                    

                        response = await _AbpUserLoginAttemptsProvider.DeleteAbpUserLoginAttempts(request);

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

