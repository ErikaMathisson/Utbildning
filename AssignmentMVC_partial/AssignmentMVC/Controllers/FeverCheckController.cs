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
        /// <summary>
        /// action for showing input form for user
        /// setting title and message for the view
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult FeverCheck()
        {
            ViewBag.Title = "Check Fever";
            ViewBag.Message = "Please enter your temperature to check if you have a fever";

            return View();
        }

        /// <summary>
        /// action for checking the users temperature
        /// </summary>
        /// <param name="temp">the temperature entered from the user</param>
        /// <returns>ActionResult</returns>
        public ActionResult CheckTemperature(Fever temp)
        {
            ViewBag.Title = "Check Fever";
            //check towards the model Fever if the parameter Temperature is required as stated in model
            if (ModelState.IsValid)
            {
                int Temperature = temp.Temperature;
                //check in the model if the temperature is a fever, no fever or very high or low temperature, send message to user
                string message = Fever.TemperatureCheck(Temperature);
                ViewBag.SickMessage = message;
                // send message to the user what temperature that was entered
                ViewBag.Message = "You entered temperature: " + Temperature;                         
            }
            //show the view FeverCheck for the user
            return View("FeverCheck");
        }



    }
}