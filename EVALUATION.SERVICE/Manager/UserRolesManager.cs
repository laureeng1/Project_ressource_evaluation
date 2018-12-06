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
    public partial class UserRolesManager
    {

        UserRolesProvider _UserRolesProvider;

        #region Singleton

        public UserRolesManager() 
        { 
          _UserRolesProvider = new UserRolesProvider();
        }
        
        /*
        private static UserRolesManager _instance;

        public static UserRolesManager Instance
        {
            get { return _instance ?? (_instance = new UserRolesManager()); }
        }
        */
        #endregion

        public async Task<BusinessResponse<UserRolesDto>> GetUserRolesById(object id)
        {
            return await _UserRolesProvider.GetUserRolesById(id);
        }
        public async Task<BusinessResponse<UserRolesDto>> GetUserRolesByCriteria(BusinessRequest<UserRolesDto> request)
        {
            return await _UserRolesProvider.GetUserRolesByCriteria(request);
        }

        
        public async Task<BusinessResponse<UserRolesDto>> SaveUserRoles(BusinessRequest<UserRolesDto> request)
        {
            var response = new BusinessResponse<UserRolesDto>();
            
            {
                TransactionQueueManager.BeginWork(request, response);                    

                try
                {
                    /*** Commencer la logique ici ***/                                                    

                    response = await _UserRolesProvider.SaveUserRoles(request);

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

        public async Task<BusinessResponse<Boolean>> DeleteUserRoles(BusinessRequest<UserRolesDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            {
                    TransactionQueueManager.BeginWork(request, response);                    

                    try
                    {
                        /*** Commencer la logique ici ***/                                                    

                        response = await _UserRolesProvider.DeleteUserRoles(request);

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

        public async Task<BusinessResponse<UserRolesDto>> DeleteCustomUserRoles(BusinessRequest<UserRolesDto> request)
        {
            var response = new BusinessResponse<UserRolesDto>();

            {
                TransactionQueueManager.BeginWork(request, response);

                try
                {
                    /*** Commencer la logique ici ***/
                    foreach (var item in request.ItemsToSave)
                    {
                        var getUserRole = await _UserRolesProvider.GetUserRolesByCriteria(new BusinessRequest<UserRolesDto>()
                        {
                            ItemToSearch = new UserRolesDto()
                            {
                                UserId = item.UserId,
                                RoleId = item.RoleId
                            }
                        });
                        if (getUserRole.HasError)
                            throw new Exception(getUserRole.Message);

                        if (getUserRole.Items.Any())
                        {
                            var itemToDelete = getUserRole.Items.FirstOrDefault();
                            itemToDelete.IsDeleted = true;
                            response = await _UserRolesProvider.SaveUserRoles(new BusinessRequest<UserRolesDto>()
                            {
                                ItemsToSave = new List<UserRolesDto>() { itemToDelete },
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

