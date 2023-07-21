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
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentCourseRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }

        public async Task<IEnumerable<StudentCourse>> GetAllStudentCourse()
        {
            var studentCourse = await _context.StudentsCourses.ToListAsync();
            return studentCourse;
        }

        public async Task<StudentCourse> GetStudentCourseById(int studentId, int courseId)
        {
            var student = await _context.StudentsCourses.FirstOrDefaultAsync(s => s.StudentenId == studentId 
                                                                                  && s.CourseId == courseId);
            if (student == null) throw new Exception("Nenhum Estudante/Curso associado a esse curso/estudante.");
            return student;
        }

        public async Task<StudentCourse> PostStudentCourseInfo(StudentCourse studentCourse)
        {
            _context.StudentsCourses.Add(studentCourse);
            await _context.SaveChangesAsync();
            return studentCourse;
        }

        public async Task<StudentCourse> UpdateStudentCourseInfo(StudentCourse studentCourse)
        {
            _context.StudentsCourses.Update(studentCourse);
            await _context.SaveChangesAsync();
            return studentCourse;
        }
    }
}
