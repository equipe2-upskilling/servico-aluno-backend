using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Domain.Entities
{
    public class StudentCourseLesson
    {
        [Key]
        public int StudentCourseLessonId { get; set; }

        
        public Lesson? LessonId { get; set; }

        
        public Course? CourseId { get; set;}

        
        public Studenten? StudentenId { get; set; }

        public bool IsCompleted { get; set; } = false;
    }
}
