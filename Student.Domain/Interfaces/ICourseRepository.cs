using Student.Domain.Entities;

namespace Student.Domain.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllCourses();
    }
}
