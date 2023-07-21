using Student.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Domain.Interfaces
{
    public interface IStudentCourseRepository
    {
        Task<IEnumerable<StudentCourse>> GetAllStudentCourse();
        Task<StudentCourse> GetStudentCourseById(int studentId,int courseId);
        Task<StudentCourse> PostStudentCourseInfo(StudentCourse studentCourse);
        Task<StudentCourse> UpdateStudentCourseInfo(StudentCourse studentCourse);
    }
}
