
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
using EVALUATION.DATA;
using EVALUATION.CORE;
using Admin.Common.Configuration;
using System.Web.Http.Routing;
using System.Net.Http;
using System.Collections.Generic;
using EVALUATION.WEB.Infrastructure;

namespace EVALUATION.Web.Models
{
    public class ModelFactory
    {

        private UrlHelper _UrlHelper;
        private AppUserManager _AppUserManager;

        public ModelFactory(HttpRequestMessage request, AppUserManager appUserManager)
        {
            _UrlHelper = new UrlHelper(request);
            _AppUserManager = appUserManager;
        }

        public UserReturnModel Create(AppMember appUser)
        {
            return new UserReturnModel
            {
                Url = _UrlHelper.Link("GetUserById", new { id = appUser.Id }),
                Id = appUser.Id,
                TenantId = appUser.TenantId,
                UserName = appUser.UserName,
                FullName = string.Format("{0} {1}", appUser.Nom, appUser.Prenoms), 
                Email = appUser.Email,

             //liste les autres champs de abpusers
                Roles = _AppUserManager.GetRolesAsync(appUser.Id).Result,
                Claims = _AppUserManager.GetClaimsAsync(appUser.Id).Result
            };

        }

        public RoleReturnModel Create(IdentityRole appRole) {

            return new RoleReturnModel
           {
               Url = _UrlHelper.Link("GetRoleById", new { id = appRole.Id }),
               Id = appRole.Id,
               Name = appRole.Name
           };

        }
    }

    public class UserReturnModel
    {

        public string Url { get; set; }
        public int Id { get; set; }
        public long TenantId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
      
        public IList<string> Roles { get; set; }
        public IList<Claim> Claims { get; set; }

    }

    public class RoleReturnModel
    {
        public string Url { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}