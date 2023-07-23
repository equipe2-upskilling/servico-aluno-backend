using Student.Application.Dtos;

namespace Student.Application.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAll();
        Task<StudentDto> GetById(int id);
        Task<StudentDto> GetByEmail(string email);
        Task Add(StudentDto studentDto);
        Task Update(StudentDto studentDto);
        Task Delete(int id);
    }
}
