using FrontEnd_Zahri.Models;
using Newtonsoft.Json;
using System.Text;

namespace FrontEnd_Zahri.Services
{
    public class StudentServices : IStudent
    {
        public async Task Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync($"https://localhost:7192/api/Student/{id}"))
                {
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        throw new Exception($"Gagal untuk hapus data");
                    }
                }

            }
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            List<Student> student = new List<Student>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7192/api/Student"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    student = JsonConvert.DeserializeObject<List<Student>>(apiResponse);
                }
            }
            return student;
        }

        public async Task<Student> GetById(int id)
        {
            Student student = new Student();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:7192/api/Student/{id}"))

                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        student = JsonConvert.DeserializeObject<Student>(apiResponse);
                    }
                }
            }
            return student;
        }

        public async Task<IEnumerable<Student>> GetByName(string name)
        {
            List<Student> student = new List<Student>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:7192/api/Student/ByName?name={name}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    student = JsonConvert.DeserializeObject<List<Student>>(apiResponse);
                }
            }
            return student;
        }

        public async Task<IEnumerable<StudentWithCourse>> GetStudent()
        {
            List<StudentWithCourse> student = new List<StudentWithCourse>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7192/api/Student/WithAll"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    student = JsonConvert.DeserializeObject<List<StudentWithCourse>>(apiResponse);
                }
            }
            return student;
        }

       
        public async Task<Student> Insert(Student obj)
        {
            Student stu = new Student();
            using (var httpClient = new HttpClient())
            {
                StringContent content =
                    new StringContent(
                    JsonConvert.SerializeObject(obj),
                    Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:7192/api/Student", content))
                    if (response.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        string apiResp = await response.Content.ReadAsStringAsync();
                        stu = JsonConvert.DeserializeObject<Student>(apiResp);

                    }
            }

            return stu;
        }

        public async Task<Student> Update(Student obj)
        {
            Student stu = await GetById(obj.ID);

            if (stu == null)
                throw new Exception($"Data Student dengan id {obj.ID} tidak ditemukan");
            StringContent content =
               new StringContent(
               JsonConvert.SerializeObject(obj),
               Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PutAsync("https://localhost:7192/api/Student", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    stu = JsonConvert.DeserializeObject<Student>(apiResponse);

                }

            }
            return stu;
        }

      
    }
}
