using Student.Application.Dtos;

namespace Student.Application.Interfaces
{
    public interface IStudentCourseService
    {
        Task <IEnumerable<StudentCourseDto>> GetAllStudentCourse ();
        Task<StudentCourseDto> GetStudentCourse (int StudentId,int CourseId);
        Task PostStudentCourseInfo(StudentCourseDto studentCourseDto);
        Task PostUrlRepository(StudentCourseDto studentCourseDto, string url);
        Task UpdateStudentCourseInfo(StudentCourseDto studentCourseDto);
    }
}
