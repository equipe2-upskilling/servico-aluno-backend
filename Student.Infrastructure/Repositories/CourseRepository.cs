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
            string _apiBase = "";
            string _apiUrl = _apiBase + "/course";

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
    }
}
