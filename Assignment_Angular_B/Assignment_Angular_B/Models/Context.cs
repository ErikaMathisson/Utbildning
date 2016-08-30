using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment_Angular_B.Models
{
    public class Context : DbContext
    {
        public Context() : base("AngularB")
        {
            this.Database.CreateIfNotExists();
        }

        public DbSet<Person> People { get; set; }
    }
}