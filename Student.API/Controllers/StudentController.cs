using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student.Application.Dtos;
using Student.Application.Interfaces;

namespace Student.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    //[Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IAuthenticationService _authenticationService;
        public StudentController(IStudentService studentService, IAuthenticationService authenticationService)
        {
            _studentService = studentService;
            _authenticationService = authenticationService;
        }

        [HttpGet("/GetAllStudent")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetAll()
        {
            var student = await _studentService.GetAll();
            if(student == null) return NotFound();
            return Ok(student);
        }

        [HttpGet("/GetStudent/{id:int}", Name = "GetStudent")]
        public async Task<ActionResult<StudentDto>> GetStudent(int id)
        {
            var student = await _studentService.GetById(id);
            if (student == null) return NotFound("Não encotrado.");
            return Ok(student);
        }
        [AllowAnonymous]
        [HttpPost("/CreateStudentWithLogin")]
        public async Task<ActionResult> PostWithCreateLogin(StudentDto studentDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            if (studentDto.Email == null) return BadRequest("Email não pode ser vazio.");
            if (studentDto.Password == null) return BadRequest("A senha não pode ser vazio.");

            bool createResult = await _authenticationService.CreateLogin(studentDto.Email, studentDto.Password);
            
            if (createResult)
            {
                await _studentService.Add(studentDto);
                return new CreatedAtRouteResult("GetStudent", new {id =  studentDto.StudentId}, studentDto);
            }
            else
            {
                throw new Exception("Falha na criação de Login. Tente Novamente.");
            }
        }
        [HttpPost("/CreateStudent")]
        public async Task<ActionResult> Post(StudentDto studentDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _studentService.Add(studentDto);
            return new CreatedAtRouteResult("GetStudent", new { id = studentDto.StudentId }, studentDto);
        }

        [HttpPut("/UpdateStudent")]
        public async Task<ActionResult> Update(StudentDto studentDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _studentService.Update(studentDto);
            return Ok(studentDto);
        }

        [HttpDelete("/DeleteStudent/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var student = await _studentService.GetById(id);
            if (student == null) return NotFound();
            await _studentService.Delete(id);
            return NoContent();
        }
    }
}
