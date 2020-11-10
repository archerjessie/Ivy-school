using System;
using IvySchool.Domain.Services;
using System.Threading.Tasks;
using IvySchool.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using IvySchool.api.ViewModel;

namespace IvySchool.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController:ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetCourseDetailById(int courseId)
        {

            var response = await _courseService.GetCourseDetail(courseId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourseAsync([FromBody] CourseDetail Course)
        {

            var response = await _courseService.CreateCourseAsync(Course);
            return Ok(response);
        }

        [HttpPost("enroll/{studentId}/{courseId}")]
        public async Task <IActionResult> EnrollCourse(int studentId, int courseId)
        {

            var response = await _courseService.EnrolledCourse(studentId,courseId);
            return Ok(response);
        }
    }
}
