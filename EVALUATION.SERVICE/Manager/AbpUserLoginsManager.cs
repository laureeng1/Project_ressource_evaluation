using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVALUATION.DATA.Provider;
using EVALUATION.CORE.Dto;
using Admin.Common.Domain;
using Admin.Common.Enum;
using Admin.Common.Helper;
using System.Threading.Tasks;

namespace EVALUATION.SERVICE.Manager
{
    public partial class AbpUserLoginsManager
    {

        #region Singleton

        AbpUserLoginsProvider _AbpUserLoginsProvider;

        public AbpUserLoginsManager()
        {
            _AbpUserLoginsProvider = new AbpUserLoginsProvider();
        }
        #endregion

        public async Task<BusinessResponse<AbpUserLoginsDto>> GetAbpUserLoginsById(object id)
        {
            return await _AbpUserLoginsProvider.GetAbpUserLoginsById(id);
        }
        public async Task<BusinessResponse<AbpUserLoginsDto>> GetAbpUserLoginsByCriteria(BusinessRequest<AbpUserLoginsDto> request)
        {
            return await _AbpUserLoginsProvider.GetAbpUserLoginsByCriteria(request);
        }

        public async Task<BusinessResponse<AbpUserLoginsDto>> SaveAbpUserLogins(BusinessRequest<AbpUserLoginsDto> request)
        {
            var response = new BusinessResponse<AbpUserLoginsDto>();
            
            {
                    TransactionQueueManager.BeginWork(request, response);                    

                    try
                    {
                        /*** Commencer la logique ici ***/                                                    

                        response = await _AbpUserLoginsProvider.SaveAbpUserLogins(request);

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

        public async Task<BusinessResponse<Boolean>> DeleteAbpUserLogins(BusinessRequest<AbpUserLoginsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            {
                    TransactionQueueManager.BeginWork(request, response);                    

                    try
                    {
                        /*** Commencer la logique ici ***/                                                    

                        response = await _AbpUserLoginsProvider.DeleteAbpUserLogins(request);

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

