using FrontEnd.Models;
using Newtonsoft.Json;
using System.Text;

namespace FrontEnd_Zahri.Services
{
    public class CourseServices : ICourse
    {
        public async Task Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.DeleteAsync($"https://localhost:7192/api/Course/{id}"))
                {
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        throw new Exception($"Gagal untuk hapus data");
                    }
                }

            }
        }

        public async Task<IEnumerable<Course>> GetAll(string token)
        {
           
            List<Course> course = new List<Course>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"{token}");
                using (var response = await httpClient.GetAsync("https://localhost:7192/api/Course"))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        course = JsonConvert.DeserializeObject<List<Course>>(apiResponse);
                    }
                    

                }
            }
            return course;
        }

        public async Task<Course> GetById(int id)
        {
            Course course = new Course();
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync($"https://localhost:7192/api/Course/{id}"))

                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        course = JsonConvert.DeserializeObject<Course>(apiResponse);
                    }
                }
            }
            return course;
        }

        public async Task<IEnumerable<Course>> GetByName(string name)
        {
            List<Course> course = new List<Course>();
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync($"https://localhost:7192/api/Course/ByName?name={name}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    course = JsonConvert.DeserializeObject<List<Course>>(apiResponse);
                }
            }
            return course;
        }

        public async Task<Course> Insert(Course obj)
        {
            Course course = new Course();
            using (var httpClient = new HttpClient())
            {
                StringContent content =
                    new StringContent(
                    JsonConvert.SerializeObject(obj),
                    Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:7192/api/Course", content))
                    if (response.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        string apiResp = await response.Content.ReadAsStringAsync();
                        course = JsonConvert.DeserializeObject<Course>(apiResp);

                    }
            }

            return course;
        }

        public async Task<Course> Update(Course obj)
        {
            Course course = await GetById(obj.CourseId);

            if (course == null)
                throw new Exception($"Data Course dengan id {obj.CourseId} tidak ditemukan");
            StringContent content =
               new StringContent(
               JsonConvert.SerializeObject(obj),
               Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.PutAsync("https://localhost:7192/api/Course", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    course = JsonConvert.DeserializeObject<Course>(apiResponse);

                }

            }
            return course;
        }
    }
}
