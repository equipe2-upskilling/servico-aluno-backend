using System.Text.Json.Serialization;

namespace Student.Application.Dtos
{
    public class StudentCourseLessonDto
    {
        [JsonIgnore]
        public int StudentCourseLessonId { get; set; }
        public int LessonId { get; set; }
        public int CourseId { get; set; }
   
        public int StudentenId { get; set; }
        [JsonIgnore]
        public LessonDto LessonDto { get; set; }
        [JsonIgnore]
        public CourseDto CourseDto { get; set; }
        [JsonIgnore]
        public StudentDto StudentDto { get; set; }
        [JsonIgnore]
        public bool IsCompleted { get; set; }
    }
}
