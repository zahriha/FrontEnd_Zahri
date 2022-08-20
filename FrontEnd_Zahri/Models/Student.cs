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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }
        // public int TotalPage { get; set; }
        //public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int PageIndex { get; set; }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }
        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
        public ICollection<Enrollment> Enrollments { get; set; }= new List<Enrollment>();
       
    }

}
