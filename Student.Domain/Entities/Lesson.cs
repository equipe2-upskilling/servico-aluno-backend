using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Domain.Entities
{
    public class Lesson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LessonId { get; set; }

        public Course Courses { get; set; }

        public int CourseId { get; set; }

        [MaxLength(100)]
        public string? TitleLesson { get; set;}

        [MaxLength(100)]
        public string? DescriptionLesson { get; set; }

        public int? DurationLesson { get; set; }
        
        [MaxLength(100)]
        public string? VideoLesson { get; set; }
    }
}
