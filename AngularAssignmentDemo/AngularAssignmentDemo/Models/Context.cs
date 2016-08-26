using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngularAssignmentDemo.Models
{
    public class Context : DbContext
    {

        public Context() : base("Angular")
        {
            this.Database.CreateIfNotExists();
        }

        public DbSet<Person> People { get; set; }
    }
}