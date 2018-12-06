using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using EVALUATION.WEB.Models;
using System.Net.Http;
using System.Web.Http.Cors;
using Admin.Common.Domain;
using Admin.Common.Enum;
using EVALUATION.CORE.Dto;
using EVALUATION.SERVICE.Manager;
using EVALUATION.WEB.Infrastructure;
using EVALUATION.WEB.Map;
using EVALUATION.WEB.Results;

namespace EVALUATION.WEB.Controllers
{
    [RoutePrefix("api/accounts")]
    public class AccountApiController : MultiTenantApiController
    {
        public AccountApiController()
        {
        }
        public AccountApiController(AppUserManager userManager)
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


    }
}