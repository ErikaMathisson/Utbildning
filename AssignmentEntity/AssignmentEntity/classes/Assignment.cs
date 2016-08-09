using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentEntity.classes
{
    class Assignment
    {
        public Assignment()
        {

        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Course AssignedToCourse { get; set; }
    }
}
