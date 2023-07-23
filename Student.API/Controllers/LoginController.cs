using Microsoft.AspNetCore.Mvc;
using Student.Application.Dtos;
using Student.Application.Interfaces;

namespace Student.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IStudentService _studentService;

        public LoginController(IAuthenticationService authenticationService, IStudentService studentService)
        {
            _authenticationService = authenticationService;
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<StudentDto> Login (string email, string password)
        {
            bool loginResult = await _authenticationService.Login(email,password);
            if (loginResult) 
            {
                var student = await _studentService.GetByEmail(email);
                return student;
            }
            else
            {
               throw new Exception("Falha no login. Verifique suas credenciais e tente novamente.");
            }
        }
    }
}
