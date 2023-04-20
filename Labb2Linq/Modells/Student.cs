using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2Linq.Modells
{
    internal class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]

        public string LName { get; set; }
        [Required]

        public int CourseID { get; set; }

        public Course Course { get; set; }

    }
}
