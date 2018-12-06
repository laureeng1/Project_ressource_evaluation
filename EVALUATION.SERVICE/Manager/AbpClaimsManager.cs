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
using Microsoft.AspNet.Identity;
using EVALUATION.DATA.SpProvider;

namespace EVALUATION.SERVICE.Manager
{
    public partial class AbpClaimsManager
    {

        AbpClaimsProvider _AbpClaimsProvider;

        #region Singleton

        public AbpClaimsManager() 
        { 
          _AbpClaimsProvider = new AbpClaimsProvider();
        }
        
        /*
        private static AbpClaimsManager _instance;

        public static AbpClaimsManager Instance
        {
            get { return _instance ?? (_instance = new AbpClaimsManager()); }
        }
        */
        #endregion

        public async Task<BusinessResponse<AbpClaimsDto>> GetAbpClaimsById(object id)
        {
            return await _AbpClaimsProvider.GetAbpClaimsById(id);
        }
        public async Task<BusinessResponse<AbpClaimsDto>> GetAbpClaimsByCriteria(BusinessRequest<AbpClaimsDto> request)
        {
            //request.TakeAll = true;
            return await _AbpClaimsProvider.GetAbpClaimsByCriteria(request);
        }

        
        public async Task<BusinessResponse<AbpClaimsDto>> SaveAbpClaims(BusinessRequest<AbpClaimsDto> request)
        {
            var response = new BusinessResponse<AbpClaimsDto>();
            
            {
                TransactionQueueManager.BeginWork(request, response);                    

                try
                {
                    /*** Commencer la logique ici ***/                                              

                    response = await _AbpClaimsProvider.SaveAbpClaims(request);

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

        public async Task<BusinessResponse<Boolean>> DeleteAbpClaims(BusinessRequest<AbpClaimsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            {
                    TransactionQueueManager.BeginWork(request, response);                    

                    try
                    {
                        /*** Commencer la logique ici ***/                                                    

                        response = await _AbpClaimsProvider.DeleteAbpClaims(request);

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

