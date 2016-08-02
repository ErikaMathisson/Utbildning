﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssignmentMVC.Models
{
    public class People
    {

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string City { get; set; }

        [Required]
        public string Search { get; set; }

        public List<People> Peoples { get; set; }

        
        public People()
        {
                     
        }

        public List<People> AddPeople()
        {
            if(this.Peoples == null)
            {
                this.Peoples = new List<People>();
            }
           

            Peoples.Add(new People { Name = "Erika", PhoneNumber = "0708430473", City = "Ronneby" });
            Peoples.Add(new People { Name = "Stina", PhoneNumber = "045523145", City = "Karlskrona" });
            Peoples.Add(new People { Name = "Calle", PhoneNumber = "0454322412", City = "Karlshamn" });
            Peoples.Add(new People { Name = "Pelle", PhoneNumber = "045412345", City = "Olofström" });
            Peoples.Add(new People { Name = "Anna", PhoneNumber = "045698765", City = "Sölvesborg" });

            return Peoples;
            
        }



    }
}