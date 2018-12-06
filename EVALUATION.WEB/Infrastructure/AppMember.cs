using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using EVALUATION.CORE;
using EVALUATION.CORE.Dto;
using EVALUATION.WEB.Models;
using Microsoft.AspNet.Identity;

namespace EVALUATION.WEB.Infrastructure
{
    public class AppMember:IdentityMember
    {
        public Tenant Tenant { get; set; }

        public DateTime? LockoutBeginDateUtc { get; set; }
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Infrastructure.AppMember, int> manager, string AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, AuthenticationType);
            // Add custom user claims here
            return userIdentity;
        }

  
        public long IdPrestataireMedical { get; set; }
        public string Photo { get; set; }
      
    }
}