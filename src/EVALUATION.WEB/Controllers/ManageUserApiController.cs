using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using EVALUATION.WEB.Models;
using System.Net.Http;
using Admin.Common.Domain;
using EVALUATION.WEB.Infrastructure;
using EVALUATION.Web.Models;

namespace EVALUATION.WEB.Controllers
{
    [Authorize]
    [RoutePrefix("api/users")]
     public class ManageUserApiController : MultiTenantApiController
     {   
        public ManageUserApiController()
        {
        }
        public ManageUserApiController(AppUserManager userManager)
        {
            UserManager = userManager;
        }

      
        // GET api/Me
        [HttpGet]
        public GetViewModel Get()
        {
            var user = UserManager.FindById(Int32.Parse(User.Identity.GetUserId()));
            return new GetViewModel() { /*Hometown = user.Hometown */ };
        }

        // Charger Permissions()
        public void /*async Task<HttpResponseMessage>*/ Permissions()
        {
            HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            //Retourner ici les informations;
        }
    }
}