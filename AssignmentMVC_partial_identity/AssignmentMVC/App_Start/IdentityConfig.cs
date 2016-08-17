using AssignmentMVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security;

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

        //katana implementing owin
        public class AppSignIn : SignInManager<ApplicationUser, string>
        {
            public AppSignIn(AppUserManager userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
            {
            }

            public static AppSignIn CreateSignInInstance(IdentityFactoryOptions<AppSignIn> options, IOwinContext context)
            {
                return new AppSignIn(context.GetUserManager<AppUserManager>(), context.Authentication);
            }

        }
    }

    public class AppRole : RoleManager<IdentityRole>
    {
        public AppRole(IRoleStore<IdentityRole, string> store) : base(store)
        {
        }

        public static AppRole CreateRoleInstance(IdentityFactoryOptions<AppRole> options, IOwinContext context)
        {
            var rs = new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>());
            return new AppRole(rs);
        }
    }
}