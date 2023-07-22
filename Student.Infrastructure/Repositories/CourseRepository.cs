using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Student.Domain.Entities;
using Student.Domain.Interfaces;
using Student.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(_apiUrl);

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
}
