using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace AssignmentMVC.Models
{
    public class ApplicationUser : IdentityUser
    {      
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(
                user: this, authenticationType: DefaultAuthenticationTypes.ApplicationCookie
                );
            return userIdentity;
        }

        // public string FullName { get; set; }

        //public string UserName { get; set; }

        //[Required]
        //public string Email { get; set; }

        //[Required]
        //public string Password { get; set; }

        //[Required]
        //public string ConfirmPassword { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    //    public City city { get; set; }





    }
}