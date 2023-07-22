namespace Student.Application.Dtos
{
    public class StudentDto : UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Endereço { get; set; }
    }
}
