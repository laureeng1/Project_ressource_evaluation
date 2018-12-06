using System;
using System.Linq;
using EVALUATION.DATA.Provider;
using EVALUATION.CORE.Dto;
using Admin.Common.Domain;
using Admin.Common.Helper;
using System.Threading.Tasks;
using EVALUATION.DATA;

namespace EVALUATION.SERVICE.Manager
{
    public partial class AbpRolesManager
    {

        #region Singleton

        AbpRolesProvider _AbpRolesProvider;

        public AbpRolesManager()
        {
            _AbpRolesProvider = new AbpRolesProvider();
        }

        #endregion

        public async Task<BusinessResponse<AbpRolesDto>> GetAbpRolesById(object id)
        {
            return await _AbpRolesProvider.GetAbpRolesById(id);
        }
        public async Task<BusinessResponse<AbpRolesDto>> GetAbpRolesByCriteria(BusinessRequest<AbpRolesDto> request)
        {
            
            return await _AbpRolesProvider.GetAbpRolesByCriteria(request);
        }


        public async Task<BusinessResponse<AbpRolesDto>> SaveAbpRoles(BusinessRequest<AbpRolesDto> request,DbManager db = null)
        {
            var response = new BusinessResponse<AbpRolesDto>();       
            {
                TransactionQueueManager.BeginWork(request, response);
                try
                    {
                    /*** Commencer la logique ici ***/
                    var abpRolesDto = request.ItemsToSave.FirstOrDefault();
                        if (abpRolesDto != null)
                            abpRolesDto.DisplayName = abpRolesDto.Name;
                            abpRolesDto.CreatedBy = request.IdCurrentUser; 
                    //abpRolesDto.CreatedBy = UserManagerExtensions.FindById(); 

                    response = await _AbpRolesProvider.SaveAbpRoles(request);


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


        public async Task<BusinessResponse<Boolean>> DeleteAbpRoles(BusinessRequest<AbpRolesDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            {
                    TransactionQueueManager.BeginWork(request, response);                    

                    try
                    {
                        /*** Commencer la logique ici ***/                                                    

                        response = await _AbpRolesProvider.DeleteAbpRoles(request);

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

