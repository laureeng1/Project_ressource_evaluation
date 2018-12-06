using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using EVALUATION.WEB.Infrastructure;
using Microsoft.AspNet.Identity.Owin;
using EVALUATION.WEB.Models;

namespace EVALUATION.WEB.Providers

{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            bool validated = context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            var allowedOrigin = "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            var userManager = context.OwinContext.GetUserManager<AppUserManager>();

            var user = await userManager.FindAsync(context.UserName, context.Password);

            // demo

            //AppMember user = new AppMember() { FullName = "ruffin", EmailAddress = "ndjoni@yahoo.fr", Id = 12 };

            if (user == null)
            {
                context.SetError("Error", "Login ou mot de passe incorrect.");
                return;
            }
            
            var oAuthIdentity = await user.GenerateUserIdentityAsync(userManager, "JWT");
            oAuthIdentity.AddClaims(RolesFromClaims.CreateRolesBasedOnClaims(oAuthIdentity));
            oAuthIdentity.AddClaims(ExtendedClaimsProvider.GetClaims(user));



            var ticket = new AuthenticationTicket(oAuthIdentity, null);

            context.Validated(ticket);

        }
    }


}