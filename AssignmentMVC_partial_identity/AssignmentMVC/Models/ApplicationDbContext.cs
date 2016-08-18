using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AssignmentMVC.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("Identityconnection", throwIfV1Schema: false)
        {

        }

        public static ApplicationDbContext CreateConnection()
        {
            return new ApplicationDbContext();
        }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }    

    }
}