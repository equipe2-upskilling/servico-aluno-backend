using Student.Application.Dtos;
using Student.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Application.Interfaces
{
    public interface IStudentCourseService
    {
        Task PostStudentCourseInfo(StudentCourseDto studentCourseDto);
    }
}
