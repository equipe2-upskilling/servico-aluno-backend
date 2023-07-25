using Student.Application.Dtos;

namespace Student.Application.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> GetAll();
        Task<CourseDto> GetById(int id);
    }
}
