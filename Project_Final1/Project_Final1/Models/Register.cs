using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ASPProject.Models;

namespace Project_Final1.Models
{
    public class Register
    {
        [Key]
        [Column(TypeName = "int")]
        public int Number { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
       
        [Required]
        [Display(Name = "Teacher Name")]
        public String TeacherName { get; set; } = "Unknown";

        [Range(0,100)]
        public int Grade { get; set; }
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        public eSemester Semester { get; set; }

        //Navigation
        public Student? Student { get; set; }
        public Course? Course { get; set; }
    }
}
