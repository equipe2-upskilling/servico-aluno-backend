using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Application.Dtos;
using Student.Application.Interfaces;

namespace Student.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private readonly IStudentCourseService _studentCourseService;

        public StudentCourseController(IStudentCourseService studentCourseService)
        {
            _studentCourseService = studentCourseService;
        }

        [HttpPost]
        public async Task AddStudentCourse([FromBody]StudentCourseDto studentCourseDto)
        {
            await _studentCourseService.PostStudentCourseInfo(studentCourseDto);
            return NoContent();

        }
    }
}
