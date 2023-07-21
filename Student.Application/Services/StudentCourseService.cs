using AutoMapper;
using Student.Application.Dtos;
using Student.Application.Interfaces;
using Student.Domain.Entities;
using Student.Domain.Enum;
using Student.Domain.Interfaces;

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

        public async Task<IEnumerable<StudentCourseDto>> GetAllStudentCourse()
        {
            var students = await _studentCourseRepository.GetAllStudentCourse();
            var studentDto = _mapper.Map<IEnumerable<StudentCourseDto>>(students);
            return studentDto;
        }

        public async Task<StudentCourseDto> GetStudentCourse(int StudentId, int CourseId)
        {
            var student = await _studentCourseRepository.GetStudentCourseById(StudentId, CourseId);
            var studentDto = _mapper.Map<StudentCourseDto>(student);
            return studentDto;
        }

        public async Task PostStudentCourseInfo(StudentCourseDto studentCourseDto)
        {
            studentCourseDto.Status = StatusCourse.Pending;
            studentCourseDto.Created = DateTime.Now;
            var InfoTransfer = _mapper.Map<StudentCourse>(studentCourseDto);
            await _studentCourseRepository.PostStudentCourseInfo(InfoTransfer);
        }

        public async Task UpdateStudentCourseInfo(StudentCourseDto studentCourseDto)
        {
            studentCourseDto.Status = StatusCourse.Enabled;
            studentCourseDto.Updated = DateTime.Now;
            var InfoTransfer = _mapper.Map<StudentCourse>(studentCourseDto);
            await _studentCourseRepository.UpdateStudentCourseInfo(InfoTransfer);
        }
    }
}
