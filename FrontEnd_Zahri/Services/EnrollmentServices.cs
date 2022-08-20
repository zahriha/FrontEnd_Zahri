using FrontEnd_Zahri.Models;
using Newtonsoft.Json;
using System.Text;

namespace FrontEnd_Zahri.Services
{
    public class EnrollmentServices : IEnrollment
    {
     
        public async Task Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync($"https://localhost:7192/api/Enrollment/{id}"))
                {
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        throw new Exception($"Gagal untuk hapus data");
                    }
                }

            }
        }
        public async Task<IEnumerable<Enrollment>> GetAll(string token)
        {
            List<Enrollment> enrollment = new List<Enrollment>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"{token}");
                using (var response = await httpClient.GetAsync("https://localhost:7192/api/Enrollment"))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        enrollment = JsonConvert.DeserializeObject<List<Enrollment>>(apiResponse);
                    }
                  }
            }
            return enrollment;
        }

        public async Task<Enrollment> GetById(int id)
        {
            Enrollment enrollment = new Enrollment();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:7192/api/Enrollment/{id}"))

                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        enrollment = JsonConvert.DeserializeObject<Enrollment>(apiResponse);
                    }
                }
            }
            return enrollment;
        }
     
        public async Task<Enrollment> Insert(Enrollment obj)
        {
            Enrollment enrollment = new Enrollment();
            using (var httpClient = new HttpClient())
            {
                StringContent content =
                    new StringContent(
                    JsonConvert.SerializeObject(obj),
                    Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:7192/api/Enrollment", content))
                    if (response.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        string apiResp = await response.Content.ReadAsStringAsync();
                        enrollment = JsonConvert.DeserializeObject<Enrollment>(apiResp);

                    }
            }

            return enrollment;
        }

        public async Task<Enrollment> Update(Enrollment obj)
        {
            Enrollment enrollment = await GetById(obj.EnrollmentID);

            if (enrollment == null)
                throw new Exception($"Data Enrollment dengan id {obj.EnrollmentID} tidak ditemukan");
            StringContent content =
               new StringContent(
               JsonConvert.SerializeObject(obj),
               Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PutAsync("https://localhost:7192/api/Enrollment", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    enrollment = JsonConvert.DeserializeObject<Enrollment>(apiResponse);

                }

            }
            return enrollment;
        }
    }
}
