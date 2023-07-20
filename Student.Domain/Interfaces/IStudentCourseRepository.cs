using Student.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Domain.Interfaces
{
    public interface IStudentCourseRepository
    {
        Task<StudentCourse> PostStudentCourseInfo(StudentCourse studentCourse);
    }
}
