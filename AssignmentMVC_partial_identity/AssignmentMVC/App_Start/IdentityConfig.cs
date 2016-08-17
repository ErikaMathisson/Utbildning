using AssignmentMVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentMVC.App_start
{
    public class AppUserManager : UserManager<ApplicationUser>
    {
        public AppUserManager(IUserStore<ApplicationUser> store) : base(store)
        {
        }

        public static AppUserManager CreateUserManagerInstance(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            var um = new AppUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));

            um.UserValidator = new UserValidator<ApplicationUser>(um)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            um.PasswordValidator = new PasswordValidator
            {
                RequireDigit = false,
                RequiredLength = 6,
                RequireLowercase = false,
                RequireNonLetterOrDigit = false,
                RequireUppercase = false
            };

            //if user has forgotten password use encrypted one
            var hashProvider = options.DataProtectionProvider;
            if (hashProvider != null)
            {
                // password will be encrypted with value sent to create method
                um.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(hashProvider.Create("fdafrykjjffdafdafda"));
            }

            // if user should be locked after faulty tries
            // after how many tries the user should be locked out
            // how long time locked out
            um.UserLockoutEnabledByDefault = true;
            um.MaxFailedAccessAttemptsBeforeLockout = 5;
            um.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(10);        
            return um;
        }
    }
}