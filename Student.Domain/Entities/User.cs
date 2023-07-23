using System.ComponentModel.DataAnnotations;

namespace Student.Domain.Entities
{
    public class User
    {
        [Required]
        [EmailAddress(ErrorMessage = "O campo Email não possui um formato de email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
