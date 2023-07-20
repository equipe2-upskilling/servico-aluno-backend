using Microsoft.AspNetCore.Mvc;
using Student.Application.Dtos;
using Student.Application.Interfaces;

namespace Student.API.Controllers
{
    [Route("student/v1/[Controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetAll()
        {
            var student = await _studentService.GetAll();
            if(student == null) return NotFound();
            return Ok(student);
        }

        [HttpGet("{id:int}", Name = "GetStudent")]
        public async Task<ActionResult<StudentDto>> GetStudent(int id)
        {
            var student = await _studentService.GetById(id);
            if (student == null) return NotFound("Não encotrado.");
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] StudentDto studentDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _studentService.Add(studentDto);
            return new CreatedAtRouteResult("GetStudent", new {id =  studentDto.Id}, studentDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var student = await _studentService.GetById(id);
            if (student == null) return NotFound();
            await _studentService.Delete(id);
            return NoContent();
        }
    }
}
