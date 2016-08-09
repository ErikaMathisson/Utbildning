using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentEntity.classes
{
    class Student
    {
        public Student()
        {
            this.Courses = new List<Course>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public List<Course> Courses { get; set; }

       
    }
}
