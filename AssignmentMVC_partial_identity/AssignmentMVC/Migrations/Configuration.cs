namespace AssignmentMVC.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AssignmentMVC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AssignmentMVC.Models.ApplicationDbContext context)
        {
            //create a rolemananager
            //var roleManager = new RoleManager<IdentityRole>(
            //    new RoleStore<IdentityRole>(context));
            ////check if the role Admin exist, if it doesn't create it
            //if (!roleManager.RoleExists("Admin"))
            //{
            //    roleManager.Create(new IdentityRole("Admin"));
            //}
            ////check if the role User exist, if it doesn't create it
            //if (!roleManager.RoleExists("User"))
            //{
            //    roleManager.Create(new IdentityRole("User"));
            //}
            
            //base.Seed(context);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
