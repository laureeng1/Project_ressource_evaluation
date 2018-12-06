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
    public partial class AbpUserClaimsManager
    {

        AbpUserClaimsProvider _AbpUserClaimsProvider;

        #region Singleton

        public AbpUserClaimsManager() 
        { 
          _AbpUserClaimsProvider = new AbpUserClaimsProvider();
        }
        
        /*
        private static AbpUserClaimsManager _instance;

        public static AbpUserClaimsManager Instance
        {
            get { return _instance ?? (_instance = new AbpUserClaimsManager()); }
        }
        */
        #endregion

        public async Task<BusinessResponse<AbpUserClaimsDto>> GetAbpUserClaimsById(object id)
        {
            return await _AbpUserClaimsProvider.GetAbpUserClaimsById(id);
        }
        public async Task<BusinessResponse<AbpUserClaimsDto>> GetAbpUserClaimsByCriteria(BusinessRequest<AbpUserClaimsDto> request)
        {
            return await _AbpUserClaimsProvider.GetAbpUserClaimsByCriteria(request);
        }

        
        public async Task<BusinessResponse<AbpUserClaimsDto>> SaveAbpUserClaims(BusinessRequest<AbpUserClaimsDto> request)
        {
            var response = new BusinessResponse<AbpUserClaimsDto>();
            
            {
                TransactionQueueManager.BeginWork(request, response);                    

                try
                {
                    /*** Commencer la logique ici ***/                                                    

                    response = await _AbpUserClaimsProvider.SaveAbpUserClaims(request);

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

        public async Task<BusinessResponse<Boolean>> DeleteAbpUserClaims(BusinessRequest<AbpUserClaimsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            {
                    TransactionQueueManager.BeginWork(request, response);                    

                    try
                    {
                        /*** Commencer la logique ici ***/                                                    

                        response = await _AbpUserClaimsProvider.DeleteAbpUserClaims(request);

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

