using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using EVALUATION.WEB.Models;
using EVALUATION.SERVICE;
using EVALUATION.CORE;
using EVALUATION.WEB.Infrastructure;

namespace EVALUATION.WEB
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // Configure the application user manager which is used in this application.
    //public class AppUserManager : UserManager<AppMember, int>
    //{
    //    public AppUserManager(IUserStore<AppMember, int> store)
    //        : base(store)
    //    {
    //    }
    //    public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options,
    //        IOwinContext context)
    //    {
    //        var manager = new AppUserManager(new UserStore<AppMember>(context.Get<ApplicationDbContext>() as DbManager));
    //        // Configure validation logic for usernames
    //        manager.UserValidator = new UserValidator<AppMember, int>(manager)
    //        {
    //            AllowOnlyAlphanumericUserNames = false,
    //            RequireUniqueEmail = true
    //        };

    //        // Configure validation logic for passwords
    //        manager.PasswordValidator = new PasswordValidator
    //        {
    //            RequiredLength = 6,
    //            RequireNonLetterOrDigit = true,
    //            RequireDigit = true,
    //            RequireLowercase = true,
    //            RequireUppercase = true,
    //        };

    //        // Configure user lockout defaults
    //        manager.UserLockoutEnabledByDefault = true;
    //        manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
    //        manager.MaxFailedAccessAttemptsBeforeLockout = 5;

    //        // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
    //        // You can write your own provider and plug it in here.
    //        //manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<AppUser>
    //        //{
    //        //    MessageFormat = "Your security code is {0}"
    //        //});
    //        //manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<AppUser>
    //        //{
    //        //    Subject = "Security Code",
    //        //    BodyFormat = "Your security code is {0}"
    //        //});
    //        //manager.EmailService = new EmailService();
    //        //manager.SmsService = new SmsService();
    //        var dataProtectionProvider = options.DataProtectionProvider;
    //        if (dataProtectionProvider != null)
    //        {
    //            manager.UserTokenProvider =
    //                new DataProtectorTokenProvider<AppMember, int>(dataProtectionProvider.Create("ASP.NET Identity"));
    //        }
    //        return manager;
    //    }
    //}
    //public class AppRoleManager : RoleManager<AppRole, int>
    //{
    //    public AppRoleManager(IRoleStore<AppRole, int> roleStore)
    //        : base(roleStore)
    //    {
    //    }

    //    public static AppRoleManager Create(IdentityFactoryOptions<AppRoleManager> options, IOwinContext context)
    //    {
    //        return new AppRoleManager(new RoleStore<AppRole>(context.Get<ApplicationDbContext>()));
    //    }
    //}

    // Configure the application sign-in manager which is used in this application.  
    public class ApplicationSignInManager : SignInManager<AppMember, int>
    {
        public ApplicationSignInManager(AppUserManager userManager, IAuthenticationManager authenticationManager) :
            base(userManager, authenticationManager)
        { }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(AppMember user)
        {
            return user.GenerateUserIdentityAsync((AppUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<AppUserManager>(), context.Authentication);
        }
    }
}
