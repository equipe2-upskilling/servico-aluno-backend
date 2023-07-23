using System.ComponentModel.DataAnnotations;

namespace Student.Domain.Enum
{
    public enum StatusCourse
    {
        [Display(Name = "Ativo")]
        Enabled = 1,

        [Display(Name = "Pendente")]
        Pending = 2,

        [Display(Name = "Inativo")]
        NotEnabled = 3
    }
}
