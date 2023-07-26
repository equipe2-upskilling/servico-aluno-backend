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
    public class StudentCourseLessonRepository : IStudentCourseLessonRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentCourseLessonRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<StudentCourseLesson>> GetAllStudentCourseLesson()
        {
            var studentCourseLessons = await _context.StudentCourseLessons.ToListAsync();
            return studentCourseLessons;
        }
        public async Task<StudentCourseLesson> GetStudentCourseLessonById(int id)
        {
            var studentCourseLesson = await _context.StudentCourseLessons.FindAsync(id);
            return studentCourseLesson;
        }
        public async Task AddStudentCourseLesson(StudentCourseLesson studentCourseLesson)
        {
            _context.StudentCourseLessons.Add(studentCourseLesson);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudentCourseLesson(StudentCourseLesson studentCourseLesson)
        {
            _context.StudentCourseLessons.Update(studentCourseLesson);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteStudentCourseLesson(StudentCourseLesson studentCourseLesson)
        {
            _context.StudentCourseLessons.Remove(studentCourseLesson);
            await _context.SaveChangesAsync();
        }
    }
}
