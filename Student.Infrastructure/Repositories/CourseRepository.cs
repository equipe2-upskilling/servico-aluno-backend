using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Student.Domain.Entities;
using Student.Domain.Interfaces;
using Student.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Student.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;
        public CourseRepository(string apiUrl)
        {
            _httpClient = new HttpClient();
            _apiUrl = apiUrl;
        }
        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            var response = await _httpClient.GetAsync($"{_apiUrl}/course/");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var courses = JsonConvert.DeserializeObject<IEnumerable<Course>>(content);
                return courses;
            }
            else
            {
                return Enumerable.Empty<Course>();
            }
        }
    }
}
