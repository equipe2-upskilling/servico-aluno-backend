using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Student.API.ProducerSQS;
using System.Text;

namespace Student.API.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AddExtensions(this WebApplicationBuilder builder) 
        {
            builder.Services.AddScoped<ProducerAWS>();
            return builder;
            
        }
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "StudentServer",
                    Description = "Servidor de Estudantes do Grupo 2"
                });

                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPatch = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPatch);

                //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                //{
                //    Name = "Authorization",
                //    Type = SecuritySchemeType.ApiKey,
                //    Scheme = "Bearer",
                //    BearerFormat = "JWT",
                //    In = ParameterLocation.Header,
                //    Description = @"JWT Authorization header using the Bearer scheme.
                //    Enter 'Bearer'[space].Example: \'Bearer 12345abcdef\'",
                //});
                //c.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //          new OpenApiSecurityScheme
                //          {
                //              Reference = new OpenApiReference
                //              {
                //                  Type = ReferenceType.SecurityScheme,
                //                  Id = "Bearer"
                //              }
                //          },
                //         new string[] {}
                //    }
                //});
            });
            return services;
        }
        public static WebApplicationBuilder AddApiSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwagger();
            return builder;
        }
    }
}
