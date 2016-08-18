using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssignmentMVC.Models
{
    public class People
    {
        public int Id { get; set; }

        /// <summary>
        /// parameter for the name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// parameter for the phonenumber
        /// </summary>
        [Required]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// parameter for the city
        /// </summary>
        [Required]
        public string City { get; set; }

        /// <summary>
        /// empty contructor
        /// </summary>               
        public People()
        {

        }

        /// <summary>
        /// Constructor for setting the People objects parameters
        /// </summary>
        /// <param name="Name">name of the people</param>
        /// <param name="PhoneNumber">phonenumber to the people</param>
        /// <param name="City">city of the people</param>
        public People(string Name, string PhoneNumber, string City)
        {
            this.Name = Name;
            this.PhoneNumber = PhoneNumber;
            this.City = City;
        }
    }
}