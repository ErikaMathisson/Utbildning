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
    }
}