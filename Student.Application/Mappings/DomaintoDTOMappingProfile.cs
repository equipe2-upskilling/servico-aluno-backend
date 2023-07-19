using AutoMapper;
using Student.Application.Dtos;
using Student.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Application.Mappings
{
    public class DomaintoDTOMappingProfile : Profile
    {
        public DomaintoDTOMappingProfile()
        {
            CreateMap<Studenten, StudentDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
        }
    }
}
