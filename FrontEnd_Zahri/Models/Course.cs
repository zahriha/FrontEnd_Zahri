using FrontEnd_Zahri.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontEnd.Models
{
    public class Course
    {
        [Display(Name = "Course ID")]

        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }= new List<Enrollment>();




    }
}
