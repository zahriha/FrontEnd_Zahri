using FrontEnd_Zahri.Services;
using Microsoft.EntityFrameworkCore;

namespace FrontEnd_Zahri.Models
{
    public class PaginatedList
    {
        public List<PaginatedStudent> PaginatedStudent { get; set; } = new List<PaginatedStudent>();
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
    }

}