using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentMVC.Models
{
    public class Projects
    {
        public List<string> proj { get; set; }

        public Projects()
        {
            proj = new List<string>();

            proj.Add("Calculator");
            proj.Add("Golf");
            proj.Add("Arena fighter");
            proj.Add("Vending machine");
            proj.Add("Html");
            proj.Add("CSS");
            proj.Add("Bootstrap");
            proj.Add("Sokoban");
            proj.Add("MVC Basics, Layout and views");
            proj.Add("MVC Basics, Forms and inputs");
            proj.Add("MVC Basics, Guessing game");

        }        
    }
}