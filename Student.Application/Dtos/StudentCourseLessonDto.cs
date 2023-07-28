namespace Student.Application.Dtos
{
    public class StudentCourseLessonDto
    {
        public int StudentCourseLessonId { get; set; }
        public int LessonId { get; set; }
        public int CourseId { get; set; }
        public int StudentenId { get; set; }
        public LessonDto LessonDto { get; set; }
        public CourseDto CourseDto { get; set; }
        public StudentDto StudentDto { get; set; }
        public bool IsCompleted { get; set; }
    }
}
