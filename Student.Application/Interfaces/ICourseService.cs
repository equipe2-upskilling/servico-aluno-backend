using Student.Application.Dtos;

namespace Student.Application.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> GetAll();
    }
}
