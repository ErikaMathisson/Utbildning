using AssignmentMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentMVC.Controllers
{
    public class FeverCheckController : Controller
    {
        // GET: FeverCheck
        public ActionResult FeverCheck()
        {
            ViewBag.Title = "Check Fever";
            ViewBag.Message = "Please enter your temperature to check if you have a fever";

            return View();
        }

        public ActionResult CheckTemperature([Bind(Include = "Temperature")]Fever temp)
        {
            ViewBag.Title = "Check Fever";

            if (ModelState.IsValid)
            {
                int Temperature = temp.Temperature;

                string message = Fever.TemperatureCheck(Temperature);          
                
                ViewBag.Message = "You entered temperature: " + Temperature;
                ViewBag.SickMessage = message;
            }

            return View("FeverCheck");
        }



    }
}