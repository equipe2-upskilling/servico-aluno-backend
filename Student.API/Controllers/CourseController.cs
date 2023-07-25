﻿using Microsoft.AspNetCore.Mvc;
using Student.Application.Dtos;
using Student.Application.Interfaces;

namespace Student.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("/GetCourses")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetAll()
        {
            var course = await _courseService.GetAll();
            if (course == null) return NotFound();
            return Ok(course);
        }

        [HttpGet("/GetCourse/{id:int}")]
        public async Task<ActionResult> GetCourse(int id)
        {
            var course = await _courseService.GetById(id);
            if(course == null) return NotFound();
            return Ok(course);
        }
    }
}
