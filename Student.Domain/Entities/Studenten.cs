using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Student.Domain.Entities
{
    public class Studenten
    {
        [Key]
        public int StudentenId { get; set; }
        [Required(ErrorMessage = "O nome não pode ser vazio")]
        [MaxLength(100)]
        [MinLength(2,ErrorMessage = "O nome não pode ter menos do que dois caracteres")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O endereço não pode ser vazio")]
        [MaxLength(300)]
        [MinLength(20, ErrorMessage = "O endereço não pode ter menos de vintes caracteres")]
        public string? Address { get; set; }
        public List<StudentCourse> StudentCourse { get; set; }
    }
}


