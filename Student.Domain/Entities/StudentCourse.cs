using Student.Domain.Enum;

namespace Student.Domain.Entities
{
    public class StudentCourse
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
