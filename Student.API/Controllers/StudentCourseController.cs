using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Student.API.ProducerSQS;
using Student.Application.Dtos;
using Student.Application.Interfaces;

namespace Student.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private readonly IStudentCourseService _studentCourseService;
        private readonly ProducerAWS _producerAWS;

        public StudentCourseController(IStudentCourseService studentCourseService, ProducerAWS producerAWS)
        {
            _studentCourseService = studentCourseService;
            _producerAWS = producerAWS;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentCourseDto>>> GetAllStudentCourse()
        {
            var studentCourse = await _studentCourseService.GetAllStudentCourse();
            return Ok(studentCourse);
        }
        [HttpGet("{StudentId:int}/{CourseId:int}")]
        public async Task<ActionResult> GetStudentCourseById(int StudentId,int CourseId)
        {
            var student = await _studentCourseService.GetStudentCourse(StudentId, CourseId);
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult> AddStudentCourse(StudentCourseDto studentCourseDto)
        {
            try
            {
                string message = JsonConvert.SerializeObject(studentCourseDto);
                await _producerAWS.SendMessageToSQS(message);

                await _studentCourseService.PostStudentCourseInfo(studentCourseDto);
                return Ok(studentCourseDto);
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro ao enviar mensagem para a fila SQS: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateStudentCourse(StudentCourseDto studentCourseDto)
        {
            await _studentCourseService.UpdateStudentCourseInfo(studentCourseDto);
            return Ok(studentCourseDto);
        }

    }
}
