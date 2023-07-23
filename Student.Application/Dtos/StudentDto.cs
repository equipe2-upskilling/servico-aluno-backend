namespace Student.Application.Dtos
{
    public class StudentDto : UserDto
    {
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
    }
}
