using Student.Domain.Entities;
using System.Text.Json.Serialization;

namespace Student.Application.Dtos
{
    public class StudentDto : UserDto
    {
        public int StudentenId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        [JsonIgnore]
        public List<StudentCourse>? StudentCourse { get; set; }
    }
}
