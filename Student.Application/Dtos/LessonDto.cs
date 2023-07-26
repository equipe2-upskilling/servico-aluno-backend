namespace Student.Application.Dtos
{
    public class LessonDto
    {
        public int LessonId { get; set; }
        public CourseDto? CourseId { get; set; }
        public string? TitleLesson { get; set; }
        public string? DescriptionLesson { get; set; }
        public int DurationLesson { get; set; }
        public string? VideoLesson { get; set; }
    }
}
