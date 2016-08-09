using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentEntity.classes
{
    class AssignmentContext : DbContext
    {
        public AssignmentContext(): base("AssignmentEntity")
        {
            this.Database.CreateIfNotExists();
        }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Assignment> Assignments { get; set; }


    }
}
