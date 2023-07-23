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
        [ForeignKey("StudenthenId")]
        public int StudentenId { get; set; }

        [Required]
        [ForeignKey("CourseId")]
        public int CourseId { get; set; }

        [EnumDataType(typeof(StatusCourse))]
        public StatusCourse Status { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Created { get; set; }

        public DateTime? Updated { get; set; }

        [JsonIgnore]
        public Studenten? Studenten { get; set; }

        [JsonIgnore]
        public Course? Course { get; set; }
        
    }
}
