using Student.Application.Dtos;
using Student.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Application.Services
{
    public class StudentService : IStudentService
    {
        public Task Add(StudentDto studentDto)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<StudentDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<StudentDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(StudentDto studentDto)
        {
            throw new NotImplementedException();
        }
    }
}
