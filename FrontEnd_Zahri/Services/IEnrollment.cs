using FrontEnd_Zahri.Models;

namespace FrontEnd_Zahri.Services
{
    public interface IEnrollment 
    {
        Task<IEnumerable<Enrollment>> GetAll(string token);
        Task<Enrollment> GetById(int id);
        Task<Enrollment> Insert(Enrollment obj);
        Task<Enrollment> Update(Enrollment obj);
        Task Delete(int id);

    }
}
 