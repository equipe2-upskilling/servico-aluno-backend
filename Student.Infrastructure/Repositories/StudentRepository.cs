using Microsoft.EntityFrameworkCore;
using Student.Domain.Entities;
using Student.Domain.Interfaces;
using Student.Infrastructure.Context;

namespace Student.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Studenten>> GetStudents()
        {
            var student = await _context.Students.ToListAsync();
            return student;
        }
        public async Task<Studenten> GetStudentById(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) throw new Exception("Não encontrado.");
            return student;
        }
        public async Task<Studenten> CreateStudent(Studenten student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }
        public async Task<Studenten> UpdateStudent(Studenten student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }
        public async Task<Studenten> RemoveStudent(Studenten studenten)
        {
            _context.Students.Remove(studenten);
            await _context.SaveChangesAsync();
            return studenten;
        }

        public Task<Studenten> GetStudentByEmail(string email)
        {
            var student = _context.Students.FirstOrDefaultAsync(s => s.Email == email);
            return student;
        }
    }
}
