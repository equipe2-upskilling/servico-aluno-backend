using Microsoft.EntityFrameworkCore;
using Student.Domain.Entities;

namespace Student.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Studenten> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Studenten>()
                .Property(s => s.StudentenId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Course>()
                .Property(s => s.CourseId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentenId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Studenten)
                .WithMany(s => s.StudentCourse)
                .HasForeignKey(sc => sc.StudentenId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourse)
                .HasForeignKey(sc => sc.CourseId);
        }
    }
}
