using System.ComponentModel.DataAnnotations;

namespace FrontEnd_Zahri.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }

    }
}
