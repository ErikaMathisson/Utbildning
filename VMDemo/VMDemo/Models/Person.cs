using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VMDemo.Models
{
    public class Person
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int SSN { get; set; }

        public Person()
        {

        }

        public Person(string fName, string lName, int personNr)
        {



        }
    }
}