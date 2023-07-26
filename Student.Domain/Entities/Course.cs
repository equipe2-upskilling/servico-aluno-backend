using Student.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Student.Domain.Entities
{
    public partial class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(100,ErrorMessage = "O Curso não pode ter mais do que cem caracteres")]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public int? Duration { get; set; }
        
        [Required]
        public double? Price { get; set; }

        public int? Enrollmentstatusid { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? RegisterDate { get; set; }

        public virtual Enrollmentstatus? Enrollmentstatus { get; set; }

        [JsonIgnore]
        public List<StudentCourse>? StudentCourse { get; set;}

        public List<Lesson> Lessons { get; set; }

    }
}
