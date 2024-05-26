using ASPProject.Models;

namespace Project_Final1.Models.ViewModels
{
    public class SearchStudent
    {
        public String Name { get; set; } = string.Empty;
        public eDepartment Department { get; set; } = eDepartment.ComputerScience;

        public List<Student>? Student { get; set; } = new List<Student>();
    }
}