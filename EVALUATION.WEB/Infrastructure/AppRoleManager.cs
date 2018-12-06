using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EVALUATION.CORE;
using EVALUATION.SERVICE;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace EVALUATION.WEB.Infrastructure
{
    public class AppRoleManager : RoleManager<AppRole, int>
    {
        public AppRoleManager(IRoleStore<AppRole, int> roleStore)
            : base(roleStore)
        {
        }

        public static AppRoleManager Create(IdentityFactoryOptions<AppRoleManager> options, IOwinContext context)
        {
            return new AppRoleManager(new RoleStore<AppRole>(context.Get<ApplicationDbContext>()));
        }

      
    }
}