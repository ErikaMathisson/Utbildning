using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssignmentMVC.Models
{
    public class Fever
    {
        /// <summary>
        /// the temperature the user entered, required field
        /// </summary>
        [Required]
        public int Temperature { get; set; }
               
        /// <summary>
        /// setting thresholds for the users temperature
        /// </summary>
        public static int Low = 34;
        public static int High = 42;
        public static int FeverTemp = 38;

        /// <summary>
        /// checking thresholds for users temperature
        /// sending back correct message to the user
        /// </summary>
        /// <param name="Temperature">the temperature entered by the user</param>
        /// <returns>string</returns>
        public static string TemperatureCheck(int Temperature)
        {
            string message = "";
            //very low temperature 
            if (Fever.Low > Temperature)
            {
                message = "Hmm you have a very low temperature, are you sure you entered the correct value... ";
            }
            //very high temperature over fever level
            else if (Fever.High < Temperature)
            {
                message = "You have a very high temperature, either you're not human or dead... ";
            }
            //temperature is in the span of fever
            else if (Temperature >= Fever.FeverTemp && Temperature <= Fever.High)
            {
               message = "You have a fever! ";
            }
            //the user have no fever
            else
            {
                message = "You have no fever, congratulations :-) ";
            }
                     
            return message;

        }

    }
}