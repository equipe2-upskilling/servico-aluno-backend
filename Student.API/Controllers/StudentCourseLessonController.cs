using Microsoft.AspNetCore.Mvc;
using Student.Application.Dtos;
using Student.Application.Interfaces;

namespace Student.API.Controllers
{
    [Route("api/[Controller]")]
    public class StudentCourseLessonController : ControllerBase
    {
        private readonly IStudentCourseLessonService _studentCourseLessonService;

        public StudentCourseLessonController(IStudentCourseLessonService studentCourseLessonService)
        {
            _studentCourseLessonService = studentCourseLessonService;
        }

        [HttpGet("/GetAllStudentCourseLesson")]
        public async Task<ActionResult<IEnumerable<StudentCourseLessonDto>>> GetAllStudentCourseLesson()
        {
            var studentCourseLessons = await _studentCourseLessonService.GetAllStudentCourseLesson();
            return Ok(studentCourseLessons);
        }

        [HttpGet("/GetStudentCourseLesson/{id:int}")]
        public async Task<ActionResult<StudentCourseLessonDto>> GetStudentCourseLesson(int id)
        {
            var studentCourseLesson = await _studentCourseLessonService.GetStudentCourseLessonById(id);
            return Ok(studentCourseLesson);
        }

        [HttpPost("/AddStudentCourseLesson")]
        public async Task<ActionResult> AddStudentCourseLesson([FromBody]StudentCourseLessonDto studentCourseLessonDto)
        {
            await _studentCourseLessonService.AddStudentCourseLesson(studentCourseLessonDto);
            return Ok();
        }
        [HttpPut("/UpdateStudentCourseLesson")]
        public async Task<ActionResult> UpdateStudentCourseLesson([FromBody] StudentCourseLessonDto studentCourseLessonDto)
        {
            await _studentCourseLessonService.UpdateStudentCourseLesson(studentCourseLessonDto);
            return Ok();
        }
        [HttpDelete("/DeleteStudentCourseLesson/{id:int}")]
        public async Task<ActionResult> DeleteStudentCourseLesson(int id)
        {
            await _studentCourseLessonService.DeleteStudentCourseLesson(id);
            return NoContent();
        }
    }
}
