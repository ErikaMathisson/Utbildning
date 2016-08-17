using AssignmentMVC.Models;
using AssignmentMVC.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentMVC.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

      //  ApplicationSignInManager 
        //public AccountController() 
        //    :this (new UserManager<ApplicationUser>(
        //    new UserStore<ApplicationUser> (new ApplicationDbContext()))

        //    {

        //    }


        public AccountController()
        {
        }

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            this.UserManager = userManager;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }


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