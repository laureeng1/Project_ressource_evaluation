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
    public partial class RolePermissionsManager
    {

        RolePermissionsProvider _RolePermissionsProvider;

        #region Singleton

        public RolePermissionsManager() 
        { 
          _RolePermissionsProvider = new RolePermissionsProvider();
        }
        
        /*
        private static RolePermissionsManager _instance;

        public static RolePermissionsManager Instance
        {
            get { return _instance ?? (_instance = new RolePermissionsManager()); }
        }
        */
        #endregion

        public async Task<BusinessResponse<RolePermissionsDto>> GetRolePermissionsById(object id)
        {
            return await _RolePermissionsProvider.GetRolePermissionsById(id);
        }
        public async Task<BusinessResponse<RolePermissionsDto>> GetRolePermissionsByCriteria(BusinessRequest<RolePermissionsDto> request)
        {
            return await _RolePermissionsProvider.GetRolePermissionsByCriteria(request);
        }

        
        public async Task<BusinessResponse<RolePermissionsDto>> SaveRolePermissions(BusinessRequest<RolePermissionsDto> request)
        {
            var response = new BusinessResponse<RolePermissionsDto>();
            
            {
                TransactionQueueManager.BeginWork(request, response);                    

                try
                {
                    /*** Commencer la logique ici ***/                                                    

                    response = await _RolePermissionsProvider.SaveRolePermissions(request);

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

        public async Task<BusinessResponse<Boolean>> DeleteRolePermissions(BusinessRequest<RolePermissionsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            {
                    TransactionQueueManager.BeginWork(request, response);                    

                    try
                    {
                        /*** Commencer la logique ici ***/                                                    

                        response = await _RolePermissionsProvider.DeleteRolePermissions(request);

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

        public async Task<BusinessResponse<RolePermissionsDto>> DeleteCustomPermissions(BusinessRequest<RolePermissionsDto> request)
        {
            var response = new BusinessResponse<RolePermissionsDto>();

            {
                TransactionQueueManager.BeginWork(request, response);

                try
                {
                    /*** Commencer la logique ici ***/
                    foreach (var item in request.ItemsToSave)
                    {
                        var getRolePermission = await _RolePermissionsProvider.GetRolePermissionsByCriteria(new BusinessRequest<RolePermissionsDto>()
                        {
                            ItemToSearch = new RolePermissionsDto()
                            {
                                PermissionId = item.PermissionId,
                                RoleId = item.RoleId
                            }
                        });
                        if (getRolePermission.HasError)
                            throw new Exception(getRolePermission.Message);

                        if (getRolePermission.Items.Any())
                        {
                            var itemToDelete = getRolePermission.Items.FirstOrDefault();
                            itemToDelete.IsDeleted = true;
                            response = await _RolePermissionsProvider.SaveRolePermissions(new BusinessRequest<RolePermissionsDto>()
                            {
                                ItemsToSave = new List<RolePermissionsDto>() { itemToDelete },
                                IdCurrentUser = request.IdCurrentUser
                            });
                            if (response.HasError)
                                throw new Exception(response.Message);
                        }

                    }

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

