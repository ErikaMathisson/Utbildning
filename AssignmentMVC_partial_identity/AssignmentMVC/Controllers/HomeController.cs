using AssignmentMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentMVC.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        ///  GET: Home
        ///  action for showing the home page 
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Home";
            ViewBag.Message = "This is a page for MVC assignment";
            return View();
        }
              
        /// <summary>
        /// action for showing the about page, just printing some information not a whole CV...
        /// using session for printing the information
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult About()
        {
            ViewBag.Title = "About";
            ViewBag.Message = "Some information...";
            Session["education"] = "Teknologie kandidat – Elektroteknik, 180 p, Blekinge Tekniska Högskola – Karlskrona";
            Session["qualification"] = "System developer, test manager, test configuration manager, project manager etc...";

            return View();
        }

        /// <summary>
        /// action for showing contact information, using model ContactInfo 
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Contact()
        {
            ViewBag.Title = "Contact information";
            var model = new AssignmentMVC.Models.ContactInfo();
            return View(model);
        }

        /// <summary>
        /// action for showing finished projects and assignments, using model Projects
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Projects()
        {
            ViewBag.Title = "Projects";
            ViewBag.Message = "Finished assignments so far...";
            var model = new AssignmentMVC.Models.Projects();
            return View(model);
        }
    }
}