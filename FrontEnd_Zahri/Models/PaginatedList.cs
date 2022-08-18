using FrontEnd_Zahri.Services;
using Microsoft.EntityFrameworkCore;

namespace FrontEnd_Zahri.Models
{
    public class PaginatedList<T> : List<Enrollment>
    {
        private readonly IEnrollment _enrollment;

        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(IEnrollment enrollment, List<Enrollment> items, int count, int pageIndex, int pageSize)
        {
            _enrollment = enrollment;
            PageIndex = pageIndex;
            this.AddRange(items);
        }
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
        


    }

}