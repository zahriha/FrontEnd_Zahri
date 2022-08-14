namespace FrontEnd_Zahri.Models
{
    public class StudentWithCourse
    {
        public string FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public List<StudentEnrollment> Enrollments { get; set; }
    }
}
