using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Admin.Common.Domain;
using EVALUATION.CORE.Dto;
using EVALUATION.SERVICE.Manager;
using EVALUATION.WEB.Infrastructure;
using EVALUATION.WEB.Map;
using EVALUATION.WEB.Results;
using EVALUATION.WEB.Models;

namespace EVALUATION.WEB.Controllers
{
    [RoutePrefix("api/dev_eval")]
    public class DevEvalApiController : MultiTenantApiController
    {
        public DevEvalApiController()
        {
        }
        public DevEvalApiController(AppUserManager userManager)
        {
            UserManager = userManager;
        }



        #region Notification

        /* [AllowAnonymous]
         [Route("NotificationIsClicked")]
         [HttpPost]
         public async Task<IHttpActionResult> NotificationIsClicked([FromBody] BusinessRequest<NotificationViewModel> request)
         {
             var convertedRequest = request.ConvertRequestToDto<NotificationViewModel, NotificationDto>();
             try
             {
                 var getFirstElementOfList = convertedRequest.ItemsToSave.FirstOrDefault();
                 //var user = await UserManager.FindByNameAsync(getFirstElementOfList.UserNamee);
                 var instanceOfManager = await new NotificationManager().GetNotificationsByCriteria(new BusinessRequest<NotificationDto>
                 {
                     ItemToSearch = new NotificationDto
                     {
                         NotificationId = getFirstElementOfList.NotificationId,
                         IdTenant = this.Tenant.Id
                     }
                 });
                 var oldNotification = instanceOfManager.Items[0];
                 BusinessResponse<NotificationDto> response = null;
                 if (oldNotification.IsClicked != null && oldNotification.IsClicked == false)
                 {
                     oldNotification.IsClicked = true;
                     var notificationDtoList = new List<NotificationDto> { oldNotification };
                     response = await new NotificationManager().SaveNotifications(new BusinessRequest<NotificationDto>
                     {
                         ItemsToSave = notificationDtoList
                     });
                     if (response.HasError)
                         return Content(HttpStatusCode.BadRequest, response).With(response.Message,
                             c => c.Content = new StringContent(response.Message));
                 }
                 return Ok(response);
             }
             catch (Exception ex)
             {
                 return Content(HttpStatusCode.BadRequest, ex)
                     .With(ex.Message, c => c.Content = new StringContent(ex.Message));
             }
         }*/

        /*[AllowAnonymous]
        [Route("GetNotificationsByCriteria")]
        [HttpPost]
        public async Task<IHttpActionResult> GetNotificationsByCriteria([FromBody] BusinessRequest<NotificationViewModel> request)
        {
            //var convertedRequest = request.ConvertRequestToDto<NotificationViewModel, NotificationDto>();
            try
            {
                var notificationManager = new NotificationManager();
                var convertedRequest = request.ConvertRequestToDto<NotificationViewModel, NotificationDto>();

                convertedRequest.ItemToSearch.IsClicked = false;
                convertedRequest.ItemToSearch.IdTenant = this.Tenant.Id;

                var response = await notificationManager.GetNotificationsByCriteria(convertedRequest);
                if (response.HasError)
                    return Content(HttpStatusCode.BadRequest, response).With(response.Message,
                        c => c.Content = new StringContent(response.Message));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex)
                    .With(ex.Message, c => c.Content = new StringContent(ex.Message));
            }
        }*/

        #endregion




        /* [Route("logout")]
         [HttpPost]
         public async Task<IHttpActionResult> Logout([FromBody]BusinessRequest<LoginViewModel> request)
         {
             var userPermissionModel = new UserPermissionModel();
             userPermissionModel.User.UserName = request.ItemToSearch.UserName;
             var user = await UserManager.FindByNameAsync(userPermissionModel.User.UserName);

             var responseSession = await new SessionUtilisateurManager().SaveSessionUtilisateurs(
                 new BusinessRequest<SessionUtilisateurDto>()
                 {
                     ItemsToSave = new List<SessionUtilisateurDto>()
                     {
                                 new SessionUtilisateurDto()
                                 {
                                     UserId = user.Id,DateDebutSession = DateTime.Now, IsConnected =false
                                 }
                     },
                     IdCurrentUser = request.IdCurrentUser,
                     IdCurrentTenant = request.IdCurrentTenant
                 }
                 );



             return Ok(responseSession);
         }*/
        [AllowAnonymous]
        [Route("Signin")]
        [HttpPost]
        public async Task<IHttpActionResult> Signin([FromBody] BusinessRequest<AbpUsersViewModels> request)
        {
            try
            {
                var convertedRequest = request.ConvertRequestToDto<AbpUsersViewModels, AbpUsersDto>();
                var response = await new AbpUsersManager().GetAbpUsersByCriteria(convertedRequest);
                if (response.HasError)
                    return Content(HttpStatusCode.BadRequest, response).With(response.Message,
                        c => c.Content = new StringContent(response.Message));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex)
                    .With(ex.Message, c => c.Content = new StringContent(ex.Message));
            }
        }


        /* PROJECTS */
        [AllowAnonymous]
        [Route("GetProjects")]
        [HttpPost]
        public async Task<IHttpActionResult> GetProjects([FromBody] BusinessRequest<ProjectsViewModels> request)
        {
            try
            {
                var convertedRequest = request.ConvertRequestToDto<ProjectsViewModels, ProjectsDto>();
                var response = await new ProjectsManager().GetProjectsByCriteria(convertedRequest);
                if (response.HasError)
                    return Content(HttpStatusCode.BadRequest, response).With(response.Message,
                        c => c.Content = new StringContent(response.Message));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex)
                    .With(ex.Message, c => c.Content = new StringContent(ex.Message));
            }
        }

        [AllowAnonymous]
        [Route("SaveProjects")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveProjects([FromBody] BusinessRequest<ProjectsViewModels> request)
        {
            try
            {
                var convertedRequest = request.ConvertRequestToDto<ProjectsViewModels, ProjectsDto>();

                var response = await new ProjectsManager().SaveProjects(convertedRequest);
                if (response.HasError)
                    return Content(HttpStatusCode.BadRequest, response).With(response.Message,
                        c => c.Content = new StringContent(response.Message));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex)
                    .With(ex.Message, c => c.Content = new StringContent(ex.Message));
            }
        }

        [AllowAnonymous]
        [Route("DeleteCustomProjects")]
        [HttpPost]
        public async Task<IHttpActionResult> DeleteCustomProjects([FromBody] BusinessRequest<ProjectsViewModels> request)
        {
            try
            {
                var convertedRequest = request.ConvertRequestToDto<ProjectsViewModels, ProjectsDto>();

                var response = await new ProjectsManager().DeleteCustomProjects(convertedRequest);
                if (response.HasError)
                    return Content(HttpStatusCode.BadRequest, response).With(response.Message,
                        c => c.Content = new StringContent(response.Message));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex)
                    .With(ex.Message, c => c.Content = new StringContent(ex.Message));
            }
        }

        /* PROJECT TASKS */
        [AllowAnonymous]
        [Route("GetProjectTasks")]
        [HttpPost]
        public async Task<IHttpActionResult> GetProjectTasks([FromBody] BusinessRequest<ProjectTasksViewModels> request)
        {
            try
            {
                var convertedRequest = request.ConvertRequestToDto<ProjectTasksViewModels, ProjectTasksDto>();
                var response = await new ProjectTasksManager().GetProjectTasksByCriteria(convertedRequest);
                if (response.HasError)
                    return Content(HttpStatusCode.BadRequest, response).With(response.Message,
                        c => c.Content = new StringContent(response.Message));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex)
                    .With(ex.Message, c => c.Content = new StringContent(ex.Message));
            }
        }

        [AllowAnonymous]
        [Route("GetProjectCollaboratorTasks")]
        [HttpPost]
        public async Task<IHttpActionResult> GetProjectCollaboratorTasks([FromBody] BusinessRequest<vProjectTasksWithCollaboratorViewModels> request)
        {
            try
            {
                var convertedRequest = request.ConvertRequestToDto<vProjectTasksWithCollaboratorViewModels, vProjectTasksWithCollaboratorDto>();
                var response = await new vProjectTasksWithCollaboratorManager().GetvProjectTasksWithCollaboratorsByCriteria(convertedRequest);
                if (response.HasError)
                    return Content(HttpStatusCode.BadRequest, response).With(response.Message,
                        c => c.Content = new StringContent(response.Message));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex)
                    .With(ex.Message, c => c.Content = new StringContent(ex.Message));
            }
        }

        [AllowAnonymous]
        [Route("SaveProjectTasks")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveProjectTasks([FromBody] BusinessRequest<ProjectTasksViewModels> request)
        {
            try
            {
                var convertedRequest = request.ConvertRequestToDto<ProjectTasksViewModels, ProjectTasksDto>();

                var response = await new ProjectTasksManager().SaveProjectTasks(convertedRequest);
                if (response.HasError)
                    return Content(HttpStatusCode.BadRequest, response).With(response.Message,
                        c => c.Content = new StringContent(response.Message));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex)
                    .With(ex.Message, c => c.Content = new StringContent(ex.Message));
            }
        }

        [AllowAnonymous]
        [Route("GetProjectTaskActions")]
        [HttpPost]
        public async Task<IHttpActionResult> GetCollaboratorTaskActions([FromBody] BusinessRequest<ProjectTaskActionsViewModels> request)
        {
            try
            {
                var convertedRequest = request.ConvertRequestToDto<ProjectTaskActionsViewModels, ProjectTaskActionsDto>();
                var response = await new ProjectTaskActionsManager().GetProjectTaskActionsByCriteria(convertedRequest);
                if (response.HasError)
                    return Content(HttpStatusCode.BadRequest, response).With(response.Message,
                        c => c.Content = new StringContent(response.Message));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex)
                    .With(ex.Message, c => c.Content = new StringContent(ex.Message));
            }
        }

        [AllowAnonymous]
        [Route("SaveProjectTaskActions")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveProjectTaskActions([FromBody] BusinessRequest<ProjectTaskActionsViewModels> request)
        {
            try
            {
                var convertedRequest = request.ConvertRequestToDto<ProjectTaskActionsViewModels, ProjectTaskActionsDto>();

                var response = await new ProjectTaskActionsManager().SaveProjectTaskActions(convertedRequest);
                if (response.HasError)
                    return Content(HttpStatusCode.BadRequest, response).With(response.Message,
                        c => c.Content = new StringContent(response.Message));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex)
                    .With(ex.Message, c => c.Content = new StringContent(ex.Message));
            }
        }

        [AllowAnonymous]
        [Route("GetCollaboratorTasks")]
        [HttpPost]
        public async Task<IHttpActionResult> GetCollaboratorTasks([FromBody] BusinessRequest<vCollaboratorTasksViewModels> request)
        {
            try
            {
                var convertedRequest = request.ConvertRequestToDto<vCollaboratorTasksViewModels, vCollaboratorTasksDto>();
                var response = await new vCollaboratorTasksManager().GetvCollaboratorTasksByCriteria(convertedRequest);
                if (response.HasError)
                    return Content(HttpStatusCode.BadRequest, response).With(response.Message,
                        c => c.Content = new StringContent(response.Message));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex)
                    .With(ex.Message, c => c.Content = new StringContent(ex.Message));
            }
        }

        [AllowAnonymous]
        [Route("GetvCollaboratorTasksByPeriod")]
        [HttpPost]
        public async Task<IHttpActionResult> GetvCollaboratorTasksByPeriod([FromBody] BusinessRequest<vCollaboratorTasksViewModels> request)
        {
            try
            {
                var convertedRequest = request.ConvertRequestToDto<vCollaboratorTasksViewModels, vCollaboratorTasksDto>();
                var response = await new vCollaboratorTasksManager().GetvCollaboratorTasksByPeriod(convertedRequest);
                if (response.HasError)
                    return Content(HttpStatusCode.BadRequest, response).With(response.Message,
                        c => c.Content = new StringContent(response.Message));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex)
                    .With(ex.Message, c => c.Content = new StringContent(ex.Message));
            }
        }

        /* USERS */
        [AllowAnonymous]
        [Route("GetAbpUsers")]
        [HttpPost]
        public async Task<IHttpActionResult> GetAbpUsers([FromBody] BusinessRequest<AbpUsersViewModels> request)
        {
            try
            {
                var convertedRequest = request.ConvertRequestToDto<AbpUsersViewModels, AbpUsersDto>();
                var response = await new AbpUsersManager().GetAbpUsersByCriteria(convertedRequest);
                if (response.HasError)
                    return Content(HttpStatusCode.BadRequest, response).With(response.Message,
                        c => c.Content = new StringContent(response.Message));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex)
                    .With(ex.Message, c => c.Content = new StringContent(ex.Message));
            }
        }

        [AllowAnonymous]
        [Route("SaveAbpUsers")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveAbpUsers([FromBody] BusinessRequest<AbpUsersViewModels> request)
        {
            try
            {
                var convertedRequest = request.ConvertRequestToDto<AbpUsersViewModels, AbpUsersDto>();
                var response = await new AbpUsersManager().SaveAbpUsers(convertedRequest);
                if (response.HasError)
                    return Content(HttpStatusCode.BadRequest, response).With(response.Message,
                        c => c.Content = new StringContent(response.Message));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex)
                    .With(ex.Message, c => c.Content = new StringContent(ex.Message));
            }
        }

        /* USER ROLES */
        [AllowAnonymous]
        [Route("GetUserRoles")]
        [HttpPost]
        public async Task<IHttpActionResult> GetUserRoles([FromBody] BusinessRequest<UserRolesViewModels> request)
        {
            try
            {
                var convertedRequest = request.ConvertRequestToDto<UserRolesViewModels, UserRolesDto>();
                var response = await new UserRolesManager().GetUserRolesByCriteria(convertedRequest);
                if (response.HasError)
                    return Content(HttpStatusCode.BadRequest, response).With(response.Message,
                        c => c.Content = new StringContent(response.Message));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex)
                    .With(ex.Message, c => c.Content = new StringContent(ex.Message));
            }
        }

        [AllowAnonymous]
        [Route("SaveUserRoles")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveUserRoles([FromBody] BusinessRequest<UserRolesViewModels> request)
        {
            try
            {
                var convertedRequest = request.ConvertRequestToDto<UserRolesViewModels, UserRolesDto>();
                var response = await new UserRolesManager().SaveUserRoles(convertedRequest);
                if (response.HasError)
                    return Content(HttpStatusCode.BadRequest, response).With(response.Message,
                        c => c.Content = new StringContent(response.Message));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex)
                    .With(ex.Message, c => c.Content = new StringContent(ex.Message));
            }
        }

        [AllowAnonymous]
        [Route("DeleteUserRoles")]
        [HttpPost]
        public async Task<IHttpActionResult> DeleteUserRoles([FromBody] BusinessRequest<UserRolesViewModels> request)
        {
            try
            {
                var convertedRequest = request.ConvertRequestToDto<UserRolesViewModels, UserRolesDto>();
                var response = await new UserRolesManager().DeleteCustomUserRoles(convertedRequest);
                if (response.HasError)
                    return Content(HttpStatusCode.BadRequest, response).With(response.Message,
                        c => c.Content = new StringContent(response.Message));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex)
                    .With(ex.Message, c => c.Content = new StringContent(ex.Message));
            }
        }


        /* ROLES */
        [AllowAnonymous]
        [Route("GetRoles")]
        [HttpPost]
        public async Task<IHttpActionResult> GetRoles([FromBody] BusinessRequest<RolesViewModels> request)
        {
            try
            {
                var convertedRequest = request.ConvertRequestToDto<RolesViewModels, RolesDto>();
                var response = await new RolesManager().GetRolesByCriteria(convertedRequest);
                if (response.HasError)
                    return Content(HttpStatusCode.BadRequest, response).With(response.Message,
                        c => c.Content = new StringContent(response.Message));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex)
                    .With(ex.Message, c => c.Content = new StringContent(ex.Message));
            }
        }

        [AllowAnonymous]
        [Route("SaveRoles")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveRoles([FromBody] BusinessRequest<RolesViewModels> request)
        {
            try
            {
                var convertedRequest = request.ConvertRequestToDto<RolesViewModels, RolesDto>();
                var response = await new RolesManager().SaveRoles(convertedRequest);
                if (response.HasError)
                    return Content(HttpStatusCode.BadRequest, response).With(response.Message,
                        c => c.Content = new StringContent(response.Message));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex)
                    .With(ex.Message, c => c.Content = new StringContent(ex.Message));
            }
        }

        [AllowAnonymous]
        [Route("CreateRole")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateRole([FromBody] BusinessRequest<RolesViewModels> request)
        {
            try
            {
                var convertedRequest = request.ConvertRequestToDto<RolesViewModels, RolesDto>();
                var response = await new RolesManager().SaveRoles(convertedRequest);
                if (response.HasError)
                    return Content(HttpStatusCode.BadRequest, response).With(response.Message,
                        c => c.Content = new StringContent(response.Message));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex)
                    .With(ex.Message, c => c.Content = new StringContent(ex.Message));
            }
        }

        [AllowAnonymous]
        [Route("SetupRole")]
        [HttpPost]
        public async Task<IHttpActionResult> SetupRole()
        {
            try
            {
                BusinessRequest<RolesDto> request = new BusinessRequest<RolesDto>();
                //var adminRole = await RoleManager.FindByNameAsync("Administrateur");
                //if (adminRole == null)
                //{
                request.ItemsToSave = new List<RolesDto>()
                    {
                        new RolesDto()
                        {
                            Name =  "Administrateur",
                            DisplayName = "Administrateur"
                        },
                        new RolesDto()
                        {
                            Name =  "Responsable",
                            DisplayName = "Responsable"
                        },
                        new RolesDto()
                        {
                            Name =  "Collaborateur",
                            DisplayName = "Collaborateur"
                        }
                    };
                request.IdCurrentUser = 3;
                var response = await new RolesManager().SaveRoles(request);
                if (response.HasError)
                    return Content(HttpStatusCode.BadRequest, response).With(response.Message,
                        c => c.Content = new StringContent(response.Message));
                return Ok(response);
                //}
                //else
                //{
                //    return Content(HttpStatusCode.OK, "Role créés avec succès");
                //}
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex)
                    .With(ex.Message, c => c.Content = new StringContent(ex.Message));
            }
        }

        [AllowAnonymous]
        [Route("GetRolePermissions")]
        [HttpPost]
        public async Task<IHttpActionResult> GetRolePermissions([FromBody] BusinessRequest<RolePermissionsViewModels> request)
        {
            try
            {
                var convertedRequest = request.ConvertRequestToDto<RolePermissionsViewModels, RolePermissionsDto>();
                var response = await new RolePermissionsManager().GetRolePermissionsByCriteria(convertedRequest);
                if (response.HasError)
                    return Content(HttpStatusCode.BadRequest, response).With(response.Message,
                        c => c.Content = new StringContent(response.Message));
                return Ok(response);


            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex)
                    .With(ex.Message, c => c.Content = new StringContent(ex.Message));
            }
        }

        [AllowAnonymous]
        [Route("SaveRolePermissions")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveRolePermission([FromBody] BusinessRequest<RolePermissionsViewModels> request)
        {
            try
            {
                var convertedRequest = request.ConvertRequestToDto<RolePermissionsViewModels, RolePermissionsDto>();
                var response = await new RolePermissionsManager().SaveRolePermissions(convertedRequest);
                if (response.HasError)
                    return Content(HttpStatusCode.BadRequest, response).With(response.Message,
                        c => c.Content = new StringContent(response.Message));
                return Ok(response);
                //// Mise a jour des permissions
                //foreach (var item in request.ItemsToSave)
                //{
                //    var allSelectedPermissions = await new RolePermissionsManager().GetRolePermissionsByCriteria(new BusinessRequest<RolePermissionsDto>()
                //    {
                //        ItemToSearch = new RolePermissionsDto()
                //        {
                //            RoleId = item.Id,
                //        }
                //    });
                //    if (allSelectedPermissions.HasError)
                //        throw new Exception(allSelectedPermissions.Message);
                //    if (allSelectedPermissions.Items.Any())
                //    {
                //        // Exclusion des permission qui n'existent plus dans le role
                //        // List<RolePermissionsDto> toDelete = allSelectedPermissions.Items.Where(i => !item.RolePermissions.Any(e => i.PermissionId.Equals(e))).ToList();
                //        List<RolePermissionsDto> toDelete = allSelectedPermissions.Items.Where(i => !item.RolePermissions.Any(e => i.PermissionId.Equals(e))).ToList();
                //        // List<RolePermissionsDto> toDelete = allSelectedPermissions.Items.Where(i => !item.RolePermissions.Any(y => i.Equals(y))).ToList();
                //        var deletedOk = await new RolePermissionsManager().DeleteRolePermissions(new BusinessRequest<RolePermissionsDto>()
                //        {
                //            ItemsToSearch = toDelete
                //        });
                //        if (deletedOk.HasError)
                //            throw new Exception(deletedOk.Message);
                //    }
                //    // Retirer les permissions qui existent deja
                //    List<int> newIdPermissionsToAdd = item.RolePermissions.Where(i => !allSelectedPermissions.Items.Any(e => i.Equals(e.PermissionId))).ToList();
                //    // Sauvegarder les nouvelles permissions
                //    BusinessRequest<RolePermissionsDto> requestRolePermission =
                //        new BusinessRequest<RolePermissionsDto>();
                //    item.RolePermissions.ForEach(el =>
                //    {
                //        if (newIdPermissionsToAdd.Contains(el))
                //        {
                //            requestRolePermission.ItemsToSave.Add(
                //                new RolePermissionsDto()
                //                {
                //                    RoleId = item.Id,
                //                    PermissionId = el
                //                }
                //            );
                //        }
                //    });
                //var resp = await new RolePermissionsManager().SaveRolePermissions(requestRolePermission);
                //if (resp.HasError)
                //    throw new Exception(resp.Message);
                //}
                // Fin permission


            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex)
                    .With(ex.Message, c => c.Content = new StringContent(ex.Message));
            }
        }

        [AllowAnonymous]
        [Route("DeleteRolePermissions")]
        [HttpPost]
        public async Task<IHttpActionResult> DeleteRolePermissions([FromBody] BusinessRequest<RolePermissionsViewModels> request)
        {
            try
            {
                var convertedRequest = request.ConvertRequestToDto<RolePermissionsViewModels, RolePermissionsDto>();
                var response = await new RolePermissionsManager().DeleteCustomPermissions(convertedRequest);
                if (response.HasError)
                    return Content(HttpStatusCode.BadRequest, response).With(response.Message,
                        c => c.Content = new StringContent(response.Message));
                return Ok(response);


            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex)
                    .With(ex.Message, c => c.Content = new StringContent(ex.Message));
            }
        }


        [AllowAnonymous]
        [Route("GetPermissions")]
        [HttpPost]
        public async Task<IHttpActionResult> GetPermissions([FromBody] BusinessRequest<PermissionsViewModels> request)
        {
            try
            {
                var convertedRequest = request.ConvertRequestToDto<PermissionsViewModels, PermissionsDto>();
                var response = await new PermissionsManager().GetPermissionsByCriteria(convertedRequest);
                if (response.HasError)
                    return Content(HttpStatusCode.BadRequest, response).With(response.Message,
                        c => c.Content = new StringContent(response.Message));
                return Ok(response);


            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex)
                    .With(ex.Message, c => c.Content = new StringContent(ex.Message));
            }
        }

        [AllowAnonymous]
        [Route("SavePermissions")]
        [HttpPost]
        public async Task<IHttpActionResult> SavePermissions([FromBody] BusinessRequest<PermissionsViewModels> request)
        {
            try
            {
                var convertedRequest = request.ConvertRequestToDto<PermissionsViewModels, PermissionsDto>();
                var response = await new PermissionsManager().SavePermissions(convertedRequest);
                if (response.HasError)
                    return Content(HttpStatusCode.BadRequest, response).With(response.Message,
                        c => c.Content = new StringContent(response.Message));
                return Ok(response);

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex)
                    .With(ex.Message, c => c.Content = new StringContent(ex.Message));
            }
        }


    }
}
