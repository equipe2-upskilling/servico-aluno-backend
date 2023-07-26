namespace Student.Application.Dtos
{
    public class StudentCourseLessonDto
    {
        public int StudentCourseLessonId { get; set; }
        public LessonDto LessonId { get; set; }
        public CourseDto CourseId { get; set; }
        public StudentDto StudentenId { get; set; }
        public bool IsCompleted { get; set; }
    }
}
