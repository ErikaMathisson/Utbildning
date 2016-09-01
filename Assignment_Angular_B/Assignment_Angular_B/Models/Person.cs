using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment_Angular_B.Models
{
    public class Person
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(25)]
        public string name { get; set; }

        [Required]
        [MinLength(6)]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        public string phone { get; set; }

        [Required]
        public string country { get; set; }
    }
}