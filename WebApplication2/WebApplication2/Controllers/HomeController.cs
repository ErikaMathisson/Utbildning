using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        //parameter comes from the html parameter name in the input form
        //get 
        //string Age only for working due to dataoverloading
        // HttpGet is default
        //     [HttpGet]

        /*      public ActionResult Index(string Name, string Age)
              {
                  return View();
              }
      */

        /*        //parameter comes from the html parameter name in the input form
                [HttpPost]
                public ActionResult Index(string Name, int Age = 0)
                {
                    return View();
                }


        */



        [HttpPost]
        public ActionResult Index([Bind(Include = "Username, Password")]Auth login)
        {

            //bind is the same way as below
            //    Auth log = new Auth();
            //    log.UserName = username;
            //    log.Password = password;


            //checks if variables is valid not empty. Needs to be required in model
            if (ModelState.IsValid)
            {
                return Content(login.UserName + " - " + login.Password);


            }

            return View();
        }


    }
}