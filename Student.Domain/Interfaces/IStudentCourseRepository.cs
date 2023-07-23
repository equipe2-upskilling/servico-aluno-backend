using Student.Domain.Entities;

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
