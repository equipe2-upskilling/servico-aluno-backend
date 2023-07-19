using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Infrastructure.EntitiesConfiguration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Studenten>
    {
        public void Configure(EntityTypeBuilder<Studenten> builder)
        {
            builder.HasKey(t => t.Id);
        }
    }
}
