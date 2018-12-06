using EVALUATION.CORE;
using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using EVALUATION.WEB.Infrastructure;
using EVALUATION.WEB.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using EVALUATION.Web.Models;

namespace EVALUATION.WEB.Controllers
{
    public class MultiTenantApiController : ApiController
    {       
        public Tenant Tenant
        {
            get
            {
                object multiTenant;
                if (!HttpContext.Current.GetOwinContext().Environment.TryGetValue("MultiTenant",
                    out multiTenant))
                {
                    throw new ApplicationException("Could not find Tenant");
                }

                return (Tenant)multiTenant;
            }
        }

        public string AppMember
        {
            get
            {
                var x = HttpContext.Current.User.Identity.Name;
                return x;
            }
        }

        private AppUserManager _userManager;
        private AppRoleManager _roleManager;
        private ModelFactory _modelFactory;
        private IAuthenticationManager _authenticationManager;
        private ApplicationSignInManager _signInManager;

        public IAuthenticationManager AuthenticationManager
        {
            get
            {
                return _authenticationManager ?? HttpContext.Current.GetOwinContext().Authentication;
            }
            set
            {
                _authenticationManager = value;
            }
        }

        public AppUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();
            }
            protected set
            {
                _userManager = value;
            }
        }
        public AppRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.Current.GetOwinContext().Get<AppRoleManager>();
            }
            protected set
            {
                _roleManager = value;
            }
        }
       
   
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        protected ModelFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(this.Request, this.UserManager);
                }
                return _modelFactory;
            }
        }
        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}