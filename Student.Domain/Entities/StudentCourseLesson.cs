using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Domain.Entities
{
    public class StudentCourseLesson
    {
        [Key]
        public int StudentCourseLessonId { get; set; }

        public Lesson Lesson { get; set; }
        public int LessonId { get; set; }

        public Course Course { get; set; }
        public int CourseId { get; set;}

        public Studenten Studenten { get; set; }
        public int StudentenId { get; set; }

        public bool IsCompleted { get; set; } = false;
    }
}
