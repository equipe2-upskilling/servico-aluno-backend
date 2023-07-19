using AutoMapper;
using Student.Application.Dtos;
using Student.Application.Interfaces;
using Student.Domain.Entities;
using Student.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDto>> GetAll()
        {
            var student = await _studentRepository.GetStudents();
            var studentDto = _mapper.Map<IEnumerable<StudentDto>>(student);
            return studentDto;
        }
        public async Task<StudentDto> GetById(int id)
        {
            var student = await _studentRepository.GetStudentById(id);
            var studentDto = _mapper.Map<StudentDto>(student);
            return studentDto;
        }
        public async Task Add(StudentDto studentDto)
        {
            var studentTransfer = _mapper.Map<Studenten>(studentDto);
            await _studentRepository.CreateStudent(studentTransfer);
            
        }
        public async Task Update(StudentDto studentDto)
        {
            var studentTransfer = _mapper.Map<Studenten>(studentDto);
            await _studentRepository.UpdateStudent(studentTransfer);
        }
        public async Task Delete(int id)
        {
            await _studentRepository.RemoveStudent(id);
        }
    }
}
