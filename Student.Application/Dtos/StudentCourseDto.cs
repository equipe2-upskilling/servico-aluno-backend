using Student.Domain.Entities;
using Student.Domain.Enum;

namespace Student.Application.Dtos
{
    public class StudentCourseDto
    {
        public int StudentCourseId { get; set; }
        public int StudentenId { get; set; }
        public int CourseId { get; set; }
        public StatusCourse Status { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Studenten? Studenten { get; set; }
        public Course? Course { get; set; }
    }
}
