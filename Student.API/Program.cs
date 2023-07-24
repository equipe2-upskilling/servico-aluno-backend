using Student.API.Extensions;
using Student.CrossCutting.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.AddApiSwagger();
builder.Services.AddInfrasctureAPI(builder.Configuration);
builder.Services.AddCors();
builder.AddExtensions();

var app = builder.Build();

var environment = app.Environment;

app.UseExceptionHandling(environment);

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
