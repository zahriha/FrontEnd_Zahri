
using FrontEnd_Zahri.Models;

namespace FrontEnd_Zahri.ViewModel
{
    public class EnrollmentEditModel
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade Grade { get; set; }
    }
}
