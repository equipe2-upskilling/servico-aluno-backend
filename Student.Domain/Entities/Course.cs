using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Student.Domain.Entities
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(100,ErrorMessage = "O Curso não pode ter mais do que cem caracteres")]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [JsonIgnore]
        public List<StudentCourse>? StudentCourse { get; set;}

    }
}
