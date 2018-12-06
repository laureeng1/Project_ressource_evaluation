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
using EVALUATION.DATA;

namespace EVALUATION.SERVICE.Manager
{
    public partial class AbpUserRolesManager
    {

        #region Singleton

        AbpUserRolesProvider _AbpUserRolesProvider;

        public AbpUserRolesManager()
        {
            _AbpUserRolesProvider = new AbpUserRolesProvider();
        }

        #endregion

        public async Task<BusinessResponse<AbpUserRolesDto>> GetAbpUserRolesById(object id)
        {
            return await _AbpUserRolesProvider.GetAbpUserRolesById(id);
        }
        public async Task<BusinessResponse<AbpUserRolesDto>> GetAbpUserRolesByCriteria(BusinessRequest<AbpUserRolesDto> request)
        {
            return await _AbpUserRolesProvider.GetAbpUserRolesByCriteria(request);
        }

        public async Task<BusinessResponse<AbpUserRolesDto>> SaveAbpUserRoles(BusinessRequest<AbpUserRolesDto> request)
        {
            var response = new BusinessResponse<AbpUserRolesDto>();
            
            {
                    TransactionQueueManager.BeginWork(request, response);                    

                    try
                    {
                        /*** Commencer la logique ici ***/                                                    

                        response =await  _AbpUserRolesProvider.SaveAbpUserRoles(request);

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

        public async Task<BusinessResponse<Boolean>> DeleteAbpUserRoles(BusinessRequest<AbpUserRolesDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            {
                    TransactionQueueManager.BeginWork(request, response);                    

                    try
                    {
                        /*** Commencer la logique ici ***/                                                    

                        response = await _AbpUserRolesProvider.DeleteAbpUserRoles(request);

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