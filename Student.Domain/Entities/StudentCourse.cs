using Student.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Domain.Entities
{
    public class StudentCourse
    {
            public int StudentenId { get; set; }
            public int CourseId { get; set; }
            public StatusCourse Status { get; set; }
            public Studenten Studenten { get; set; }
            public Course Course { get; set; }
        
    }
}
