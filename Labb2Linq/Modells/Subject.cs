using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2Linq.Modells
{
    internal class Subject
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int TeacherID { get; set; }
        [Required]
        public int CourseID { get; set; }
        public Teacher Teacher { get; set; }
        public Course Course { get; set; }
    }
}
