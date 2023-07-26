using Student.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Domain.Interfaces
{
    public interface IStudentCourseLessonRepository
    {
        Task<IEnumerable<StudentCourseLesson>> GetAllStudentCourseLesson();
        Task<StudentCourseLesson> GetStudentCourseLessonById(int id);
        Task AddStudentCourseLesson(StudentCourseLesson studentCourseLesson);
        Task UpdateStudentCourseLesson(StudentCourseLesson studentCourseLesson);
        Task DeleteStudentCourseLesson(StudentCourseLesson studentCourseLesson);
    }
}
