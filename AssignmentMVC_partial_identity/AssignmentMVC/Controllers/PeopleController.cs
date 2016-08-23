using AssignmentMVC.App_start;
using AssignmentMVC.Models;
using AssignmentMVC.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static AssignmentMVC.App_start.AppUserManager;

namespace AssignmentMVC.Controllers
{
    [Authorize]
    public class PeopleController : Controller
    {

        //public static List<Country> countries = new List<Country>
        //{
        //    new Country { Id = 1, CountryName = "USA" },
        //    new Country { Id = 2, CountryName = "Sverige" },
        //    new Country { Id = 3, CountryName = "Norway" }
        //};

        //public static List<City> Cities = new List<City>
        //    {
        //        new City { Id = 1, CityName ="Washington" },
        //        new City { Id = 2, CityName ="Los Angeles" },
        //        new City { Id = 3, CityName ="San Fransisco" },



        //    };








        //public ActionResult GetCities(int id = 1)
        //{
        //    if (id>0)
        //    {
        //        var tempCities = Cities.Where(x => x.countries.Id = id);
        //        return PartialView(tempCities);

        //    }

        // //   var cities = Cities.where(x => x.Country.id == id);

        //    return PartialView();

        //}


        public PeopleController()
        {
        }

        /// <summary>
        /// setting parameters
        /// </summary>
        /// <param name="role">role for adding to a user</param>
        /// <param name="userManager">usermanager for a user</param>
        /// <param name="signIn">signin manager</param>
        public PeopleController(AppRole role, AppUserManager userManager, AppSignIn signIn)
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

        // GET: People
        /// <summary>
        /// action for rendering the view ShowPeople, sending the model of a list of peoples to it
        /// </summary>
        /// <returns>view</returns>
        public ActionResult ShowPeople()
        {
            //fetch peoples with attributes as UsersViewModel            
            var Peoples = UserManager.Users.ToList().Select(x => new UsersViewModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                City = x.City,
                Country = x.Country,
                Email = x.Email,
                Id = x.Id
            }).ToList();

            //return the list to the view
            return View(Peoples);
        }

        /// <summary>
        /// action for rendering a partialview
        /// </summary>
        /// <param name="p">model to be sent to partialview</param>
        /// <returns></returns>
        public ActionResult RenderPeople(UsersViewModel p)
        {
            return PartialView("_people", p);
        }

        /// <summary>
        /// action for searching for peoples in the list of static peoples
        /// </summary>
        /// <param name="Search">the string to be searched for</param>
        /// <returns>view with searchresult</returns>
        [HttpPost]
        public ActionResult SearchPeople(string Search)
        {
            // creating a new list of peoples for the search result
            List<UsersViewModel> searchResult = new List<UsersViewModel>();
            //fetch peoples
            var Peoples = UserManager.Users.ToList().Select(x => new UsersViewModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                City = x.City,
                Country = x.Country,
                Id = x.Id
            }).ToList();

            //make sure the list of peoples, Peoples, have elements in it before doing the search 
            if (Peoples != null)
            {
                //loop through the elements in the Peoples list
                foreach (var item in Peoples)
                {
                    //check if firstname and lastname exist before doing a search
                    if (item.FirstName != null && item.LastName != null)
                    {
                        // check if name contains the search string from the user
                        if (item.FirstName.Contains(Search) || item.LastName.Contains(Search))
                        {
                            // if an element is found add it to the new list of peoples
                            searchResult.Add(item);
                        }
                    }
                }
            }

            // if no elements where found in the search display this information to the user.
            if (searchResult.Count == 0)
            {
                ViewBag.Message = "No entries found";
            }

            // render the view with the list of found elements
            return View("ShowPeople", searchResult);
        }

        /// <summary>
        /// action for adding a user to the database 
        /// </summary>
        /// <param name="model">the user who should be added</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> AddUser(UsersViewModel model, string UserName, string Password)
        {
            // if all information added ok
            if (ModelState.IsValid)
            {
                // create a new user
                var user = new ApplicationUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = UserName,
                    Email = model.Email
                };

                //try and save the user to database
                var result = await UserManager.CreateAsync(user, Password);

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
                    var registeredUser = await UserManager.FindByNameAsync(UserName);
                    // check if the role for the user should be admin or user and assign to the added user

                    await UserManager.AddToRoleAsync(registeredUser.Id, "User");

                    //the user is registered and saved ok to database, log in automatically
                    //LogInViewModel vm = new LogInViewModel();
                    //vm.UserName = UserName;
                    //vm.Password = model.Password;
                    //await Login(vm);
                    return RedirectToAction("Index", "Home");
                }
            }
            // information entered not ok, reload the view RegisterUser
            return View("RegisterUser", model);
        }


        /// <summary>
        /// Deletes a user based on email and redirects to home page
        /// </summary>
        /// <param name="search">email from user</param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(string search)
        {
            // finds a user based on email
            var user = await UserManager.FindByEmailAsync(search);

            //try and delete the user to database
            var result = await UserManager.DeleteAsync(user);

            //the user was not deleted ok               
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
            //redirect to homepage
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// show a list of countries for the user
        /// </summary>
        /// <returns></returns>
        public ActionResult AddCountry()
        {
            // new database connection
            ApplicationDbContext db = new ApplicationDbContext();
            //collect a list of countries 
            List<Country> countries = db.Countries.Include("Cities").ToList();
            return View(countries);
        }

        /// <summary>
        /// action for adding a country
        /// </summary>
        /// <param name="CountryName">name of the country</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddCountry(string CountryName, string CityName)
        {
            // create a new database
            ApplicationDbContext db = new ApplicationDbContext();
            //check if the model is ok
            if (ModelState.IsValid)
            {
                //create a new country and try to add it to database
                Country country = new Country();
                country.CountryName = CountryName;



                if (CityName != null)
                {
                    City city = new City();
                    city.CityName = CityName;

                    //    country.Cities.Add(city);
                }

                try
                {
                    db.Countries.Add(country);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return View();
                }

            }
            else
            {
                // send out error message to user
                ViewBag.Message = "Information not added";
            }
            //return a list of countries to user
            List<Country> countries = db.Countries.Include("Cities").ToList();
            return View(countries);
        }

    }
}
