using Student.Domain.Entities;

namespace Student.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Studenten>> GetStudents();
        Task<Studenten> GetStudentById (int id);
        Task<Studenten> GetStudentByEmail(string email);
        Task<Studenten> CreateStudent(Studenten student);
        Task<Studenten> UpdateStudent(Studenten student);
        Task<Studenten> RemoveStudent(Studenten student);
    }
}
