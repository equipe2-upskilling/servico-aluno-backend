using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student.API.Filters;
using Student.Application.Dtos;
using Student.Application.Interfaces;

namespace Student.API.Controllers
{
    [Route("api/[Controller]")]
    //[ApiController]
    
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
        [Authentication]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetAll()
        {
            var student = await _studentService.GetAll();
            if(student == null) return NotFound();
            return Ok(student);
        }

        [HttpGet("/GetStudent/{id:int}", Name = "GetStudent")]
        [Authentication]
        public async Task<ActionResult<StudentDto>> GetStudent(int id)
        {
            var student = await _studentService.GetById(id);
            if (student == null) return NotFound("Não encotrado.");
            return Ok(student);
        }

        [Authentication]
        [HttpGet("/GetStudentByEmail")]
        public async Task<ActionResult<StudentDto>> GetStudentByEmail([FromBody] string username)
        {
            var student = await _studentService.GetByEmail(username);
            if (student == null) return NotFound("Aluno não encontrado");
            return Ok(student);
        }
        
        [HttpPost("/CreateStudentWithLogin")]
        [AllowAnonymous]
        public async Task<ActionResult> PostWithCreateLogin([FromBody]StudentDto studentDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            if (studentDto.Username == null) return BadRequest("Email não pode ser vazio.");   
            if (studentDto.Password == null) return BadRequest("A senha não pode ser vazio.");
            UserDto user = new UserDto()
            {
                Username = studentDto.Username,
                Password = studentDto.Password
            };
            
            bool createResult = await _authenticationService.CreateLogin(user);
            
            if (createResult)
            {
                await _studentService.Add(studentDto);
                return new CreatedAtRouteResult("GetStudent", new {id =  studentDto.StudentenId}, studentDto);
            }
            else
            {
                throw new Exception("Falha na criação de Login. Tente Novamente.");
            }
        }
        [HttpPost("/CreateStudent")]
        [Authentication]
        public async Task<ActionResult> Post([FromBody]StudentDto studentDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _studentService.Add(studentDto);
            return new CreatedAtRouteResult("GetStudent", new { id = studentDto.StudentenId }, studentDto);
        }

        [HttpPut("/UpdateStudent")]
        [Authentication]
        public async Task<ActionResult> Update([FromBody]StudentDto studentDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _studentService.Update(studentDto);
            return Ok(studentDto);
        }

        [HttpDelete("/DeleteStudent/{id:int}")]
        [Authentication]
        public async Task<ActionResult> Delete(int id)
        {
            var student = await _studentService.GetById(id);
            if (student == null) return NotFound();
            await _studentService.Delete(id);
            return NoContent();
        }
    }
}
