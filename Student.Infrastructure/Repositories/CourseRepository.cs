using Newtonsoft.Json;
using Student.Domain.Entities;
using Student.Domain.Interfaces;

namespace Student.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        public CourseRepository()
        {}
        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            string _apiBase = "https://localhost:7215/";
            string _apiUrl = _apiBase + "all";

            using HttpClient client = new();
            var response = await client.GetAsync(_apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var courses = JsonConvert.DeserializeObject<IEnumerable<Course>>(content);
                return courses;
            }
            else
            {
                throw new Exception("Erro ao receber os cursos");
            }

        }

        public async Task<Course> GetCourse(int id)
        {
            string _apiBase = "https://localhost:7215/";
            string _apiUrl = _apiBase + $"api/Course/{id}";

            using HttpClient client = new();
            var response = await client.GetAsync(_apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var courses = JsonConvert.DeserializeObject<Course>(content);
                return courses;
            }
            else
            {
                throw new Exception("Erro ao receber os cursos");
            }
        }
    }
}
