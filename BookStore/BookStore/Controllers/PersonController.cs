using BookStore.Models;
using BookStore.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static BookStore.App_Start.IdentityConfig;
using static BookStore.App_Start.IdentityConfig.AppUserManager;

namespace BookStore.Controllers
{
    public class PersonController : Controller
    {
        /// <summary>
        /// empty constructor for controller
        /// </summary>
        public PersonController()
        {

        }

        
        /// <summary>
        /// setting parameters
        /// </summary>
        /// <param name="role">role for adding to a user</param>
        /// <param name="userManager">usermanager for a user</param>
        /// <param name="signIn">signin manager</param>
        public PersonController(AppRole role, AppUserManager userManager, AppSignIn signIn)
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

        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// function for register a person to the database
        /// </summary>
        /// <param name="user">person whom should be registered</param>
        /// <returns>Json</returns>
        [AllowAnonymous]
        [HttpPost]
        public async System.Threading.Tasks.Task<JsonResult> RegisterPerson([Bind(Include = "UserName, FirstName, LastName, PassWord, ConfirmPassword, Email, Address, ZipCode, City, PhoneNumber")] RegisterUserViewModel user)
        {
            // if all information added ok
            if (ModelState.IsValid)
            {
                // create a new user
                var person = new User
                {
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Address = user.Address,
                    ZipCode = user.ZipCode,
                    City = user.City,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber
                };

                //try and save the user to database
                var result = await UserManager.CreateAsync(person, user.Password);

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
                    var registeredUser = await UserManager.FindByNameAsync(user.UserName);


                    /////////

                   

                    var Peoples = UserManager.Users.ToList();




                    ////  create a rolemananager
                    //var roleManager = new RoleManager<IdentityRole>(
                    //    new RoleStore<IdentityRole>(context));
                    ////check if the role Admin exist, if it doesn't create it
                    //if (!roleManager.RoleExists("Admin"))
                    //{
                    //    roleManager.Create(new IdentityRole("Admin"));
                    //}
                    ////check if the role User exist, if it doesn't create it
                    //if (!roleManager.RoleExists("User"))
                    //{
                    //    roleManager.Create(new IdentityRole("User"));
                    //}

                    //base.Seed(context);









                    // check if the role for the user should be admin or user and assign to the added user
                    //if (model.Admin == true)
                    //{
                    //    await UserManager.AddToRoleAsync(registeredUser.Id, "Admin");
                    //}
                    //else
                    //{
                    //    await UserManager.AddToRoleAsync(registeredUser.Id, "User");
                    //}

                    //the user is registered and saved ok to database, log in automatically
                    //LogInViewModel vm = new LogInViewModel();
                    //vm.UserName = model.UserName;
                    //vm.Password = model.Password;
                    //await Login(vm);
                    //return RedirectToAction("Index", "Home");

                    return Json("Success");
                }
            }
            else
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));             

                return Json(message);

            }

            return Json("NonValid");
        
        }
    }
}