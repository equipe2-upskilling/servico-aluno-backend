using System.Text.Json.Serialization;

namespace Student.Application.Dtos
{
    public class LessonDto
    {
        public int LessonId { get; set; }
        public int? CourseId { get; set; }
        public string? TitleLesson { get; set; }
        public string? DescriptionLesson { get; set; }
        public int DurationLesson { get; set; }
        public string? VideoLesson { get; set; }
        [JsonIgnore]
        public CourseDto CourseDto { get; set; }
    }
}
