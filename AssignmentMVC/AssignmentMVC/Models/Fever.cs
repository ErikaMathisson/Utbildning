using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssignmentMVC.Models
{
    public class Fever
    {
        [Required]
        public int Temperature { get; set; }

        public static int Low = 36;
        public static int High = 42;
        public static int FeverTemp = 38;



        public static string TemperatureCheck(int Temperature)
        {
            string message = "";

            if (Fever.Low > Temperature)
            {
                message = "Hmm you have a very low temperature... ";
            }
            else if (Fever.High < Temperature)
            {
                message = "You have a very high temperature either you're not human or dead... ";
            }
            else if (Temperature >= Fever.FeverTemp && Temperature <= Fever.High)
            {
               message = "You have a fever ";
            }
            else
            {
                message = "You have no fever, congratulations :-) ";

            }
                     
            return message;

        }

    }
}