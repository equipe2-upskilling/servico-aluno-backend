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
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentCourseRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public async Task<StudentCourse> PostStudentCourseInfo(StudentCourse studentCourse)
        {
            _context.Add(studentCourse);
            await _context.SaveChangesAsync();
            return studentCourse;
        }
    }
}
