using Microsoft.AspNetCore.Mvc;
using Student.Application.Dtos;
using Student.Application.Interfaces;

namespace Student.API.Controllers
{
    public class StudentCourseLessonController : ControllerBase
    {
        private readonly IStudentCourseLessonService _studentCourseLessonService;

        public StudentCourseLessonController(IStudentCourseLessonService studentCourseLessonService)
        {
            _studentCourseLessonService = studentCourseLessonService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentCourseLessonDto>>> GetAllStudentCourseLesson()
        {
            var studentCourseLessons = await _studentCourseLessonService.GetAllStudentCourseLesson();
            return Ok(studentCourseLessons);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<StudentCourseLessonDto>> GetStudentCourseLesson(int id)
        {
            var studentCourseLesson = await _studentCourseLessonService.GetStudentCourseLessonById(id);
            return Ok(studentCourseLesson);
        }

        [HttpPost]
        public async Task<ActionResult> AddStudentCourseLesson(StudentCourseLessonDto studentCourseLessonDto)
        {
            await _studentCourseLessonService.AddStudentCourseLesson(studentCourseLessonDto);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> UpdateStudentCourseLesson(StudentCourseLessonDto studentCourseLessonDto)
        {
            await _studentCourseLessonService.UpdateStudentCourseLesson(studentCourseLessonDto);
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteStudentCourseLesson(int id)
        {
            await _studentCourseLessonService.DeleteStudentCourseLesson(id);
            return NoContent();
        }
    }
}
