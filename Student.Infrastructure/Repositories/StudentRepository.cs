using Student.Domain.Entities;
using Student.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public Task<Studenten> CreateStudent(Studenten student)
        {
            throw new NotImplementedException();
        }

        public Task<Studenten> GetStudentById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Studenten>> GetStudents()
        {
            throw new NotImplementedException();
        }

        public Task<Studenten> RemoveStudent(Studenten student)
        {
            throw new NotImplementedException();
        }

        public Task<Studenten> UpdateStudent(Studenten student)
        {
            throw new NotImplementedException();
        }
    }
}
