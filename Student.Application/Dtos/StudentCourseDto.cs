using Student.Domain.Entities;
using Student.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Application.Dtos
{
    public class StudentCourseDto
    {
        public int StudentCourseId { get; set; }
        public int StudentenId { get; set; }
        public int CourseId { get; set; }
        public StatusCourse Status { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; }
        public Studenten Studenten { get; set; }
        public Course Course { get; set; }
    }
}
