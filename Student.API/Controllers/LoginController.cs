using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student.Application.Dtos;
using Student.Application.Interfaces;

namespace Student.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IStudentService _studentService;

        public LoginController(IAuthenticationService authenticationService, IStudentService studentService)
        {
            _authenticationService = authenticationService;
            _studentService = studentService;
        }

        [HttpPost("/LoginApplication")]
        public async Task<StudentDto> LoginApplication ([FromBody]UserDto userDto)
        {
            bool loginResult = await _authenticationService.Login(userDto);
            if (loginResult) 
            {
                var student = await _studentService.GetByEmail(userDto.Username);
                return student;
            }
            else
            {
               throw new Exception("Falha no login. Verifique suas credenciais e tente novamente.");
            }
        }
    }
}
