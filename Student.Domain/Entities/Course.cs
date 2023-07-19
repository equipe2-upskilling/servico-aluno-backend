using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Domain.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100,ErrorMessage = "O Curso não pode ter mais do que cem caracteres")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

    }
}
