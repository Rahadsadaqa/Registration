using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Win32;
using ASPProject.Models;

namespace Project_Final1.Models
{
    public class Student
    {
       public int StudentId { get; set; }
        [Required(ErrorMessage = "Enter name")]
        [MinLength(10)]
        [MaxLength(30)]
        public String Name { get; set; } = "Unknown";
        public eDepartment Department { get; set; }
        [Phone]
        public String? Phone { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;

        //Navigation
        public IEnumerable<Register>? Regesteration { get; set; }
    }
}
