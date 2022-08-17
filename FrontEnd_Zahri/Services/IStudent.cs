using FrontEnd_Zahri.Models;

namespace FrontEnd_Zahri.Services
{
    public interface IStudent
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetById(int id);
        Task<Student> Insert(Student obj);
        Task<Student> Update(Student obj);
        Task Delete(int id);
        Task<IEnumerable<Student>> GetByName(string name);
        Task<IEnumerable<StudentWithCourse>> GetStudent();

    }
}
