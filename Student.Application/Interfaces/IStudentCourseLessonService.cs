using Student.Application.Dtos;

namespace Student.Application.Interfaces
{
    public interface IStudentCourseLessonService
    {
        Task<IEnumerable<StudentCourseLessonDto>> GetAllStudentCourseLesson();
        Task<StudentCourseLessonDto> GetStudentCourseLessonById(int id);
        Task AddStudentCourseLesson(StudentCourseLessonDto studentCourseLessonDto);
        Task UpdateStudentCourseLesson(StudentCourseLessonDto studentCourseLessonDto);
        Task UpdateisCompletedStudentCourseLesson(StudentCourseLessonDto studentCourseLessonDto);
        Task DeleteStudentCourseLesson(int id);
    }
}
