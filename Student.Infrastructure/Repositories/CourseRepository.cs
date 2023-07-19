using Microsoft.EntityFrameworkCore;
using Student.Domain.Entities;
using Student.Domain.Interfaces;
using Student.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            var courses = await _context.Courses.ToListAsync();
            return courses;
        }
    }
}
