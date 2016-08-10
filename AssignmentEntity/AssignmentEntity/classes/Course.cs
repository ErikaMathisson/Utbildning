using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentEntity.classes
{    class Course
    {
        public Course()
        {
            this.Assignments = new List<Assignment>();
            this.Students = new List<Student>();
           
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Assignment> Assignments { get; set; }

        public Teacher AssignedToTeacher { get; set; }

        public List<Student> Students { get; set; }
    }

   

}
