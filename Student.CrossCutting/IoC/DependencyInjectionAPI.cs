using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Student.Application.Interfaces;
using Student.Application.Mappings;
using Student.Application.Services;
using Student.Domain.Interfaces;
using Student.Infrastructure.Context;
using Student.Infrastructure.Repositories;

namespace Student.CrossCutting.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrasctureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseNpgsql(connectionString));

            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICourseService, CourseService>();

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentService, StudentService>();

            services.AddScoped<IStudentCourseRepository, StudentCourseRepository>();
            services.AddScoped<IStudentCourseService, StudentCourseService>();

            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<IStudentCourseLessonRepository, StudentCourseLessonRepository>();
            services.AddScoped<IStudentCourseLessonService, StudentCourseLessonService>();

            services.AddAutoMapper(typeof(DomaintoDTOMappingProfile));

            return services;
        }
    }
}
