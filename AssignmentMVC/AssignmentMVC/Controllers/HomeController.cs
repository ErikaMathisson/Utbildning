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
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = "Home";
            ViewBag.Message = "This is a page for MVH assignment";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "About";
            ViewBag.Message = "Some information...";
            Session["education"] = "Teknologie kandidat – Elektroteknik, 180 p, Blekinge Tekniska Högskola – Karlskrona";
            Session["qualification"] = "System developer, test manager, test configuration manager, project manager etc...";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Contact information";
            var model = new AssignmentMVC.Models.ContactInfo();
            return View(model);
        }

        public ActionResult Projects()
        {
            ViewBag.Title = "Projects";
            ViewBag.Message = "Finished assignments so far";
            var model = new AssignmentMVC.Models.Projects();
            return View(model);
        }

   /*     public ActionResult CheckFever()
        {
            ViewBag.Title = "Check Fever";
            ViewBag.Message = "Enter your temperature";
            return View();
        }

    */
    /*
        public ActionResult FeverCheck()
        {
            ViewBag.Message = "Enter a temperature";
           
            return View();
        }

        public ActionResult Create(string feverTemperature)
        {

            ViewBag.Message = "Your temperature is: " + feverTemperature;

            return View("FeverCheck");

        }
    */

    }
}