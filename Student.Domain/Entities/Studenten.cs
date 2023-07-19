namespace Student.Domain.Entities
{
    public class Studenten
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Course Course { get; set; }
    }
}
