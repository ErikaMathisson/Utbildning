using AssignmentMVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentMVC.Controllers
{
    public class AccountController : Controller
    {
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



        //public class RegisterViewModel
        //{
        //    [Required]
        //    [EmailAddress]
        //    [Display(Name = "Email")]
        //    public string Email { get; set; }

        //    [Required]
        //    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //    [DataType(DataType.Password)]
        //    [Display(Name = "Password")]
        //    public string Password { get; set; }

        //    [DataType(DataType.Password)]
        //    [Display(Name = "Confirm password")]
        //    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //    public string ConfirmPassword { get; set; }
        //}





        [HttpPost]
        public ActionResult AddUser([Bind(Include = "UserName, Email, Password, ConfirmPassword")] ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                var context = new ApplicationDbContext();
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

              

                
                var result = userManager.Create(user: new ApplicationUser()
                {
                    UserName = user.UserName,
                    Email = user.Email,                    
                    
                }, password: user.PasswordHash);


                //var userAdd = new ApplicationUser { UserName = user.Email, Email = user.Email };
                //var result =  UserManager.Create(userAdd, user.Password);

                //user = new ApplicationUser()
                //{
                //    FirstName = user.FirstName,
                //    LastName = user.LastName,
                //    Email = user.Email,
                //    Password = user.Password,
                //    ConfirmPassword = user.ConfirmPassword
                //};

            //    var result = userManager.Create(user);

                if (!result.Succeeded)
                {
                    ViewBag.Message = result;

                   // return result.Errors.First();
                }
                else
                {
                    ViewBag.Message = "Registration complete";

                }
               
                





                //    ApplicationUser user;

                //    ApplicationUserStore Store = new ApplicationUserStore(new ApplicationDbContext());
                //    ApplicationUserManager userManager = new ApplicationUserManager(Store);
                //    user = new ApplicationUser
                //    {
                //        UserName = "TestUser",
                //        Email = "TestUser@test.com"
                //    };

                //    var result = userManager.Create(user);
                //    if (!result.Succeeded)
                //    {
                //        return result.Errors.First();
                //    }
                //    return "User Added";


            }
            else
            {
                ViewBag.Message = "Not all required information entered, try again";
            }



                //}



                //render the view with the list of peoples
                //   return View("ShowPeople", Peoples);

                return View("RegisterUser", user);
        }





    }






}