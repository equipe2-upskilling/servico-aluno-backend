using AutoMapper;
using Student.Application.Dtos;
using Student.Application.Interfaces;
using Student.Domain.Entities;
using Student.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Student.Application.Services
{
    public class StudentCourseService : IStudentCourseService
    {
        private readonly IStudentCourseRepository _studentCourseRepository;
        private readonly IMapper _mapper;

        public StudentCourseService(IStudentCourseRepository studentCourseRepository, IMapper mapper)
        {
            _studentCourseRepository = studentCourseRepository;
            _mapper = mapper;
        }

        public async Task PostStudentCourseInfo(StudentCourseDto studentCourseDto)
        {
            var InfoTransfer = _mapper.Map<StudentCourse>(studentCourseDto);
            await _studentCourseRepository.PostStudentCourseInfo(InfoTransfer);
        }
    }
}
