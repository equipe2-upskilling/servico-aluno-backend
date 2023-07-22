using Student.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Application.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAll();
        Task<StudentDto> GetById(int id);
        Task<StudentDto> getByEmail(string email);
        Task Add(StudentDto studentDto);
        Task Update(StudentDto studentDto);
        Task Delete(int id);
    }
}
