using FrontEnd.Models;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd_Zahri.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }
    public class Enrollment
    {
        [Display(Name = "Enrollment ID")]

        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }
        public string StudentName { get; set; }
        public string CourseTitle { get; set; }
        public Course Course { get; set; }
        public Student Student{ get; set; }

        public int PageIndex { get; private set; }
        public int TotalPage { get; private set; }

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
                return (PageIndex < TotalPage);
            }
        }

    }
}
