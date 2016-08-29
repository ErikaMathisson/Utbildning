using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment_Angular2.Models
{
    public class Person
    {
        //add dataannotations
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        [EmailAddress]      
        public string email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Country { get; set; }

    }
}