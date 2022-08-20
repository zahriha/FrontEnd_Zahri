using FrontEnd_Zahri.Models;

namespace FrontEnd_Zahri.Services
{
    public interface IUser
    {
        Task<UserRegister> Insert(UserRegister obj);
        Task<Authentication> Login(UserRegister user);

    }
}
