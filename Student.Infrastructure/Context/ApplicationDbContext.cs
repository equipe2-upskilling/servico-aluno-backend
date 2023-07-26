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
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<StudentCourseLesson> StudentCourseLessons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Studenten>()
         .HasKey(s => s.StudentenId);

            modelBuilder.Entity<StudentCourseLesson>()
                .HasKey(scl => scl.StudentCourseLessonId);

            modelBuilder.Entity<Course>()
                .HasKey(c => c.CourseId);

            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => sc.StudentCourseId);

            modelBuilder.Entity<Lesson>()
                .HasKey(l => l.LessonId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Studenten)
                .WithMany()
                .HasForeignKey(sc => sc.StudentenId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany()
                .HasForeignKey(sc => sc.CourseId);

            modelBuilder.Entity<Lesson>()
                .HasOne(l => l.Courses)
                .WithMany(c => c.Lessons) // Use a propriedade de navegação "Lessons" (plural) em vez de "Lesson" (singular)
                .HasForeignKey(l => l.CourseId);

            modelBuilder.Entity<StudentCourseLesson>()
                .HasOne(scl => scl.Lesson)
                .WithMany()
                .HasForeignKey(scl => scl.LessonId);

            modelBuilder.Entity<StudentCourseLesson>()
                .HasOne(scl => scl.Studenten)
                .WithMany()
                .HasForeignKey(scl => scl.StudentenId);
        }
    }
}
