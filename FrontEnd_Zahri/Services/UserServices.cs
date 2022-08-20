using FrontEnd_Zahri.Models;
using Newtonsoft.Json;
using System.Text;

namespace FrontEnd_Zahri.Services
{
    public class UserServices : IUser
    {
        public async Task<UserRegister> Insert(UserRegister obj)
        {
            UserRegister userRegister = new UserRegister();
            using (var httpClient = new HttpClient())
            {
                StringContent content =
                    new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:7192/api/User", content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        userRegister = JsonConvert.DeserializeObject<UserRegister>(apiResponse);
                    }
                }
            }
            return userRegister;
        }

        public async Task<Authentication> Login(UserRegister user)
        {
            Authentication authentication = new Authentication();
            UserRegister newUser = new UserRegister();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:7192/api/User/Login", content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        authentication = JsonConvert.DeserializeObject<Authentication>(apiResponse);
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Error : {apiResponse}");
                    }
                }
            }
            return authentication;
        }
    }
}
