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


        //








      //  ApplicationSignInManager 
        //public AccountController() 
        //    :this (new UserManager<ApplicationUser>(
        //    new UserStore<ApplicationUser> (new ApplicationDbContext()))

        //    {

        //    }


        public AccountController()
        {
        }

        //public AccountController(UserManager<ApplicationUser> userManager)
        //{
        //    this.UserManager = userManager;
        //}

        public AccountController(AppRole role, AppUserManager userManager, AppSignIn signIn)
        {
            _role = role;
            _signIn = signIn;
            _userManager = userManager;

        }

        private AppRole _role;

        public AppRole RoleManager
        {
            //?? check if object is null
            get { return _role ?? HttpContext.GetOwinContext().Get<AppRole>(); }
            set { _role = value; }
        }

        private AppUserManager _userManager;

        public AppUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().Get<AppUserManager>(); }
            set { _userManager = value; }
        }

        private AppSignIn _signIn;

        public AppSignIn SignIn
        {
            get { return _signIn ?? HttpContext.GetOwinContext().Get<AppSignIn>(); }
            set { _signIn = value; }
        }




        //    public UserManager<ApplicationUser> UserManager { get; private set; }


        // GET: Account

        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult RegisterUser()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Reg([Bind(Include ="Email, UserName, PassWord")]RegUserViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = vm.UserName,
                    Email = vm.Email

                };

                var admin = await UserManager.FindByEmailAsync("admin@admin.se");

                if (admin == null)
                {
                    await RoleManager.CreateAsync(new IdentityRole("Admin"));
                    await RoleManager.CreateAsync(new IdentityRole("User"));
                    var regStatus = await UserManager.CreateAsync(user, vm.Password);

                    var uAdmin = await UserManager.FindByEmailAsync("admin@admin.se");
                    await UserManager.AddToRoleAsync(uAdmin.Id, "Admin");
                    return RedirectToAction("Login");

                }



                var regStatusUser = await UserManager.CreateAsync(user, vm.Password);

                if (regStatusUser.Succeeded)
                {
                    var registeredUser = await UserManager.FindByEmailAsync(vm.Email);
                    await UserManager.AddToRoleAsync(registeredUser.Id, "User");
                    return RedirectToAction("Login");

                }
            }

            return View();
        }



        public ActionResult Logggin()
        {
            return View();
        }

        // login in with email doesn't work with method passwordsigninasync... change
        public async Task<ActionResult> Logggin([Bind(Include = "UserEmail, PassWord")]LogInViewModel2 vm, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByEmailAsync(vm.UserEmail);
                if (user == null)
                {
                    user = await UserManager.FindByNameAsync(vm.UserEmail);

                }

                if (user != null)
                {
                    var signInStatus = await SignIn.PasswordSignInAsync(vm.UserEmail, vm.Password, false, true);

                    switch (signInStatus)
                    {
                        case SignInStatus.Success:
                            if (!string.IsNullOrWhiteSpace(ReturnUrl))
                            {
                                return Redirect(ReturnUrl);

                            }
                            return RedirectToAction("Index");
                                                 
                        //case SignInStatus.LockedOut:
                        //    break;
                        //case SignInStatus.RequiresVerification:
                        //    break;
                        case SignInStatus.Failure:
                            ViewBag.Errors = "Incorrect username or password";
                            break;
                        default:
                            break;
                    }

                }


            }

            return View();



        }





        public ActionResult Logout()
        {
            SignIn.AuthenticationManager.SignOut();
            return RedirectToAction("Index");

        }






        [AllowAnonymous]
        [HttpPost]
        public ActionResult AddUser(ApplicationUserViewModel model)
        {
            if (ModelState.IsValid)
            {


                var context = new ApplicationDbContext();
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var result = userManager.Create(user: new ApplicationUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,

                }, password: model.Password);

                if (!result.Succeeded)
                {
                    ViewBag.Message = result;
                }
                else
                {                   
                    return RedirectToAction("Index", "Home");
                }
                
            }          
            return View("RegisterUser", model);
        }


        [AllowAnonymous]
        public ActionResult LogInUser()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogInUser(LogInViewModel user)
        {
            if (ModelState.IsValid)
            {
                //var result = await SignInManager.PasswordSignInAsync(
                //    UserName: user.UserName, PasswordHasher: user.Password, isPersistent: true, shouldLockout: false);

                ViewBag.Message = "Well done";

            }




            return View();
        }




    }
}