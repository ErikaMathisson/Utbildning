using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssignmentMVC.ViewModels
{
    public class ApplicationUserViewModel
    {
        [Required]
        [Display(Name ="Username: ")]
        public string UserName { get; set; }
        
        [Required]
        [Display(Name = "Email: ")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password: ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password: ")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Admin?")]
        public bool Admin { get; set; }

        //[Display(Name = "Country:")]
        //public int Country { get; set; }

        //[Display(Name = "City:")]
        //public int City { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

    }
}