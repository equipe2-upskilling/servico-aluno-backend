using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Student.Domain.Entities
{
    public class Studenten : User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentenId { get; set; }

        [Required(ErrorMessage = "O nome não pode ser vazio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "O endereço não pode ser vazio")]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "O nome deve ter entre 10 e 300 caracteres")]
        public string? Address { get; set; }
        
        [JsonIgnore]
        public List<StudentCourse>? StudentCourse { get; set; }
    }
}


