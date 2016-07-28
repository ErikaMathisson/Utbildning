using AssignmentMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentMVC.Controllers
{
    public class GuessingGameController : Controller
    {
        //
        /// <summary>
        ///  GET: GuessingGame
        /// action for loading the GuessingGame view, action get.
        /// sending message to user
        /// </summary>
        /// <returns></returns>
        public ActionResult GuessingGame(int Guess = 0)
        {
            ViewBag.Title = "Guessing game";
            ViewBag.Message = "Enter an integer between 1 and 100";
            //generating a random number
            int number = Guessing.randomNumber;
            //storing the random number to the session
            Session["RandomNumber"] = number;
            //creating a list for the users guesses
            List<int> guesses = new List<int>();
                      
            //storing the guess list to the session
            Session["guesses"] = guesses;
                        
            return View();
        }

        /// <summary>
        /// action for loading the GuessingGame and checking values after the user entered a value. Binding to model Guessing
        /// </summary>
        /// <param name="g">Guessing model to bind data to</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public ActionResult GuessingGame([Bind(Include = "Guess")] Guessing g)
        {
            ViewBag.Title = "Guessing game - playing game";

            //check if enterd value is valid that is required
            if (ModelState.IsValid)
            {
                string message;

                //getting the number the user guessed
                int guessedNumber = g.Guess;

                // check if the guessed number is within scope
                if (guessedNumber < Guessing.OutOfRangeMin || guessedNumber > Guessing.OutOfRangeMax )
                {
                    message = Guessing.OutOfRangeMessage;
                }
                else
                {
                    //fetch guesses already made and stored in the session
                    var guesses = Session["guesses"] as List<int>;
                    //add the new guess to the list
                    guesses.Add(guessedNumber);
                    //store the list with added element to the session
                    Session["guesses"] = guesses;
                    
                    //check if the random number and guessed number match, to high number entered or to low number entered
                    // print correct message to the user
                    if ((int)Session["RandomNumber"] == guessedNumber)
                    {
                        message = Guessing.CorrectMessage;
                        // the user has guessed a correct number, setting parameter for what form to use in the view
                        ViewBag.Winner = "yes";
                    }
                    else if ((int)Session["RandomNumber"] > guessedNumber)
                    {
                        message = Guessing.ToLowMessage;
                    }
                    else
                    {
                        message = Guessing.ToHighMessage;
                    }
                }
                ViewBag.Message = message;
            }

            return View();
        }
    }
}

