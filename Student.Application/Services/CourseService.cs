using AutoMapper;
using Student.Application.Dtos;
using Student.Application.Interfaces;
using Student.Domain.Interfaces;

namespace Student.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseDto>> GetAll()
        {
            var course = await _courseRepository.GetAllCourses();
            var courseDto = _mapper.Map<IEnumerable<CourseDto>>(course);
            return courseDto;
        }

        public async Task<CourseDto> GetById(int id)
        {
            var course = await _courseRepository.GetCourse(id);
            var courseDto = _mapper.Map<CourseDto>(course);
            return courseDto;
        }
    }
}
