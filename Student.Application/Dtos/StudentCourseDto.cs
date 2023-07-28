using Student.Domain.Entities;
using Student.Domain.Enum;
using System.Text.Json.Serialization;

namespace Student.Application.Dtos
{
    public class StudentCourseDto
    {
        [JsonIgnore]
        public int StudentCourseId { get; set; }
        public int StudentenId { get; set; }
        public int CourseId { get; set; }
        [JsonIgnore]
        public StatusCourse Status { get; set; }
        [JsonIgnore]
        public DateTime Created { get; set; }
        [JsonIgnore]
        public DateTime Updated { get; set; }
        [JsonIgnore]
        public Studenten? Studenten { get; set; }
        [JsonIgnore]
        public Course? Course { get; set; }
    }
}
