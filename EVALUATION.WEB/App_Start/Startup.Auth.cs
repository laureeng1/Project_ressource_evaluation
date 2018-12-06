using System;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
//using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security.Jwt;
using Owin;
using EVALUATION.WEB.Models;
using EVALUATION.WEB.Providers;
using EVALUATION.CORE;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using System.Configuration;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using EVALUATION.WEB.Infrastructure;
using Newtonsoft.Json.Serialization;

namespace EVALUATION.WEB
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864

        public void ConfigureAuth(IAppBuilder app)
        {
            HttpConfiguration httpConfig = new HttpConfiguration();
            ConfigureOAuthTokenGeneration(app);
            ConfigureOAuthTokenConsumption(app);
            ConfigureMultiTenant(app);
            
            app.UseWebApi(httpConfig);
        }


        private void ConfigureOAuthTokenGeneration(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            //var issuer = string.Format("{0}://{1}", HttpContext.Current.GetOwinContext().Request.Scheme, HttpContext.Current.GetOwinContext().Request.Uri.Host);
            var issuer = string.Format("{0}://{1}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Host);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);


            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {

                //For Dev enviroment only (on production should be AllowInsecureHttp = false)
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new CustomOAuthProvider(),
                //AccessTokenFormat = new CustomJwtFormat("http://localhost:59425")
                AccessTokenFormat = new CustomJwtFormat(issuer)
            };

            // OAuth 2.0 Bearer Access Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
        }

        private void ConfigureOAuthTokenConsumption(IAppBuilder app)
        {

            // var issuer = "http://localhost:59425";
            //var issuer = string.Format("{0}://{1}", HttpContext.Current.GetOwinContext().Request.Scheme, HttpContext.Current.GetOwinContext().Request.Uri.Host);
            var issuer = string.Format("{0}://{1}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Host);
            string audienceId = ConfigurationManager.AppSettings["as:AudienceId"];
            byte[] audienceSecret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["as:AudienceSecret"]);

            // Api controllers with an [Authorize] attribute will be validated with JWT
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = new[] { audienceId },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, audienceSecret)
                    }
                });

            // Enable the application to use a cookie to store information for the signed in user
            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            //    // LoginPath = new PathString("/Account/Login"),
            //    LoginPath = new PathString("/api/accounts/Login"),
            //    Provider = new CookieAuthenticationProvider
            //    {
            //        // Enables the application to validate the security stamp when the user logs in.
            //        // This is a security feature which is used when you change a password or add an external login to your account.  

            //        OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<AppUserManager, AppMember, int>(
            //             validateInterval: TimeSpan.FromMinutes(30),
            //             regenerateIdentityCallback: (manager, appMember) => appMember.GenerateUserIdentityAsync(manager),
            //             getUserIdCallback: (id) => (Int32.Parse(id.GetUserId())))
            //    }
            //});
        }

        private void ConfigureMultiTenant(IAppBuilder app)
        {
            app.Use(async (ctx, next) =>
            {
                Tenant tenant = await new MultiTenantApp().GetTenantBasedOnUrl(ctx.Request.Uri.Host);
                //  Tenant tenant = new Tenant() { Id=2, Name="RMO", TenancyName="RMO" };
                if (tenant == null)
                {
                    throw new ApplicationException("tenant not found");
                }

                ctx.Environment.Add("MultiTenant", tenant);
                await next();

            });
        }


    }
}
