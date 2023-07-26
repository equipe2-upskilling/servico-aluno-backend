using Student.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Student.Domain.Entities
{
    public class StudentCourse
    {
        [Key]
        public int StudentCourseId { get; set; }

        [Required]
        public int StudentenId { get; set; }

        [Required]
        public int CourseId { get; set; }

        [EnumDataType(typeof(StatusCourse))]
        public StatusCourse Status { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Created { get; set; }

        public DateTime? Updated { get; set; }

        public bool IsCompleted { get; set; }

        [MaxLength(100)]
        public string UrlRepository { get; set; }

        public double Grade { get; set; }

        [JsonIgnore]
        public Studenten? Studenten { get; set; }

        [JsonIgnore]
        public Course? Course { get; set; }
        
    }
}
