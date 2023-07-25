using Student.Domain.Enum;

namespace Student.Application.Dtos
{
    public partial class CourseDto
    {
        public int CourseId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Duration { get; set; }
        public double? Price { get; set; }
        public int? Enrollmentstatusid { get; set; }
        public DateTime? RegisterDate { get; set;}
        public virtual Enrollmentstatus? Enrollmentstatus { get; set; }
    }
}
