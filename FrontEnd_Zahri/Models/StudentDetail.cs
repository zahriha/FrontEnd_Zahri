namespace FrontEnd_Zahri.Models
{
     public class StudentDetail
    {
        public string FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public List<EnrollmentDetail> Enrollments { get; set; }
    }
}

