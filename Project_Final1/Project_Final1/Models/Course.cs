using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Microsoft.Win32;
using System.ComponentModel.DataAnnotations;

namespace Project_Final1.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Enter course subject")]
        [MinLength(10)]
        public String Subject { get; set; } = String.Empty;
        [DataType(DataType.MultilineText)]
        public String? Description { get; set; }

        //Navigation
        public  IEnumerable<Register>? Regesteration { get; set; }
    }
}
