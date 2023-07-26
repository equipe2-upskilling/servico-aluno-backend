using AutoMapper;
using Student.Application.Dtos;
using Student.Application.Interfaces;
using Student.Domain.Entities;
using Student.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Student.Application.Services
{
    public class StudentCourseLessonService : IStudentCourseLessonService
    {
        private readonly IStudentCourseLessonRepository _studentCourseLessonRepository;
        private readonly IMapper _mapper;

        public StudentCourseLessonService(IStudentCourseLessonRepository studentCourseLessonRepository, IMapper mapper)
        {
            _studentCourseLessonRepository = studentCourseLessonRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentCourseLessonDto>> GetAllStudentCourseLesson()
        {
            var studentCourseLesson = await _studentCourseLessonRepository.GetAllStudentCourseLesson();
            var studentCourseLessonDto = _mapper.Map<IEnumerable<StudentCourseLessonDto>>(studentCourseLesson);
            return studentCourseLessonDto;
        }
        public async Task<StudentCourseLessonDto> GetStudentCourseLessonById(int id)
        {
            var studentCourseLesson = await _studentCourseLessonRepository.GetStudentCourseLessonById(id);
            var studentCourseLessonDto = _mapper.Map<StudentCourseLessonDto>(studentCourseLesson);
            return studentCourseLessonDto;
        }
        public async Task AddStudentCourseLesson(StudentCourseLessonDto studentCourseLessonDto)
        {
            var studentCourseLesson = _mapper.Map<StudentCourseLesson>(studentCourseLessonDto);
            await _studentCourseLessonRepository.AddStudentCourseLesson(studentCourseLesson);
            
        }
        public async Task UpdateStudentCourseLesson(StudentCourseLessonDto studentCourseLessonDto)
        {
            var studentCourseLesson = _mapper.Map<StudentCourseLesson>(studentCourseLessonDto);
            await _studentCourseLessonRepository.UpdateStudentCourseLesson(studentCourseLesson);

        }
        public async Task DeleteStudentCourseLesson(int id)
        {
            var studentResult = _studentCourseLessonRepository.GetStudentCourseLessonById(id).Result;
            await _studentCourseLessonRepository.DeleteStudentCourseLesson(studentResult);
        }
    }
}
