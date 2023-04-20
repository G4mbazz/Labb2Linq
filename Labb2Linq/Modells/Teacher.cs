using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2Linq.Modells
{
    internal class Teacher
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }

    }
}
