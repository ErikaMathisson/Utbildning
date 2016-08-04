using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssignmentMVC.Models
{
    public class Guessing
    {
       /// <summary>
       /// parameter for the users guess, required
       /// </summary>
        [Required]
        public int Guess { get; set; }

        /// <summary>
        /// creating a randomgenerator for generating a new randomnumber
        /// </summary>
        public static Random RandomGen = new Random();

        /// <summary>
        /// creating a new random number between 1 and 100
        /// </summary>
        public static int randomNumber
        {
            get { return RandomGen.Next(1, 101); }
        }

        /// <summary>
        /// The minimum value
        /// </summary>
        public static int OutOfRangeMin = 1;

        /// <summary>
        /// The maximum value
        /// </summary>
        public static int OutOfRangeMax = 100;

        /// <summary>
        /// setting a message for if user entered a too high number
        /// </summary>
        public static string ToHighMessage
        {
            get { return "You entered a too high number"; }
        }

        /// <summary>
        /// setting a message for if the user entered a too low number
        /// </summary>
        public static string ToLowMessage
        {
            get { return "You entered a too low number"; }

        }

        /// <summary>
        /// setting a message for when user entered a number out of range
        /// </summary>
        public static string OutOfRangeMessage
        {
            get { return "Entered number is outside range 1-100"; }
        }

        /// <summary>
        /// setting a message for if the user entered the correct number
        /// </summary>
        public static string CorrectMessage
        {
            get { return "Congratulations you guessed right!! If you want to play again enter a new number and press the button (this will not be a guess though) :-)"; }
        }
    }
}