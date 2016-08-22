using AssignmentMVC.App_start;
using AssignmentMVC.Models;
using AssignmentMVC.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static AssignmentMVC.App_start.AppUserManager;

namespace AssignmentMVC.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public AccountController()
        {
        }

        /// <summary>
        /// setting parameters
        /// </summary>
        /// <param name="role">role for adding to a user</param>
        /// <param name="userManager">usermanager for a user</param>
        /// <param name="signIn">signin manager</param>
        public AccountController(AppRole role, AppUserManager userManager, AppSignIn signIn)
        {
            _role = role;
            _signIn = signIn;
            _userManager = userManager;
        }

        //property for rolemanager and get and set method
        private AppRole _role;
        public AppRole RoleManager
        {
            //?? check if object is null in that case get role from OwinContext
            get { return _role ?? HttpContext.GetOwinContext().Get<AppRole>(); }
            set { _role = value; }
        }

        //property for usermanager and get and set method
        private AppUserManager _userManager;
        public AppUserManager UserManager
        {
            // check if object is null in that case get usermanager from OwinContext            
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); }
            set { _userManager = value; }
        }

        // property for signInManager and get and set method
        private AppSignIn _signIn;
        public AppSignIn SignIn
        {
            // check if object is null in that case get signinmanager from owincontext
            get { return _signIn ?? HttpContext.GetOwinContext().Get<AppSignIn>(); }
            set { _signIn = value; }
        }

        /// <summary>
        /// action for showing the register user page, user don't need to be logged in for seeing this page
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult RegisterUser()
        {
            return View();
        }        

        /// <summary>
        /// action for adding a user to the database and automatially log in the user if added ok
        /// </summary>
        /// <param name="model">the user who should be added</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> AddUser(ApplicationUserViewModel model)
        {
            // if all information added ok
            if (ModelState.IsValid)
            {
                // create a new user
                var user = new ApplicationUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    Email = model.Email
                };

                //try and save the user to database
                var result = await UserManager.CreateAsync(user, model.Password);

                //the user was not saved ok               
                if (!result.Succeeded)
                {
                    // retrieve information about what went wrong and add the message to the view
                    string message = "";
                    if (result.Errors != null)
                    {
                        foreach (var error in result.Errors)
                        {
                            message = message + error.ToString() + " ";
                        }
                    }
                    ViewBag.Message = message;
                }
                else
                {
                    var registeredUser = await UserManager.FindByNameAsync(model.UserName);
                    // check if the role for the user should be admin or user and assign to the added user
                    if (model.Admin == true)
                    {
                        await UserManager.AddToRoleAsync(registeredUser.Id, "Admin");
                    }
                    else
                    {
                        await UserManager.AddToRoleAsync(registeredUser.Id, "User");
                    }

                    //the user is registered and saved ok to database, log in automatically
                    LogInViewModel vm = new LogInViewModel();
                    vm.UserName = model.UserName;
                    vm.Password = model.Password;
                    await Login(vm);
                    return RedirectToAction("Index", "Home");
                }
            }
            // information entered not ok, reload the view RegisterUser
            return View("RegisterUser", model);
        }    

        /// <summary>
        /// action for showing the log in page for the user
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// action for trying to log in a user
        /// </summary>
        /// <param name="user">user who are trying to log in</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LogInViewModel user)
        {
            //check if information entered ok
            if (ModelState.IsValid)
            {
                // trying to log in the user
                var status = await SignIn.PasswordSignInAsync(user.UserName, user.Password,
                    isPersistent: false, shouldLockout: true);
                // check if user is logged in ok
                switch (status)
                {
                    //user logged in, return to home page
                    case SignInStatus.Success:
                        return RedirectToAction("Index", "Home");
                    //user not logged in, show information for the user
                    case SignInStatus.Failure:
                        ViewBag.Message = "Incorrect username or password";
                        break;
                    default:
                        break;
                }
            }
            // user didn't enter information correct reload the same view
            return View(user);
        }

        /// <summary>
        /// Action for logging out a user and redirect to home page
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOutUser()
        {
            SignIn.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }
    }
}