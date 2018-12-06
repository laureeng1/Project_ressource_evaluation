﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
 using INEXA.ERP.Data;
using INEXA.ERP.Core;
using Inexa.Admin.Common.Configuration;

namespace INEXA.ERP.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class AppMember : IdentityMember
    {
        public Tenant Tenant { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppMember,int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : DbManager
    {
        public ApplicationDbContext(string connectionName)
            : base(connectionName)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext(WebConfigApplicationFactory.GetWebConfigApplication().CoreConnexionString);
        }
    }
}