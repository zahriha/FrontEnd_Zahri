namespace FrontEnd_Zahri.Models
{
    public class StudentEnrollment
    {
        public int EnrollmentID { get; set; }
        public int Grade { get; set; }
        public StudentCourse Course { get; set; }
    }
}
