using AutoMapper;
using Student.Application.Dtos;
using Student.Domain.Entities;

namespace Student.Application.Mappings
{
    public class DomaintoDTOMappingProfile : Profile
    {
        public DomaintoDTOMappingProfile()
        {
            CreateMap<Studenten, StudentDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<StudentCourse, StudentCourseDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Lesson, LessonDto>().ReverseMap();
            CreateMap<StudentCourseLesson, StudentCourseLessonDto>().ReverseMap();
        }
    }
}
