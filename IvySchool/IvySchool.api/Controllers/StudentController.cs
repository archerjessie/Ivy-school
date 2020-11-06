using System;
using System.Threading.Tasks;
using IvySchool.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace IvySchool.api.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class StudentController : ControllerBase
        {
        private readonly IStudentService _studentService;

            public StudentController(IStudentService studentService)
            {
                 _studentService = studentService;
            }

        [HttpGet("students")]
        public async Task<IActionResult> GetStudentList()
        {

            var response = await _studentService.GetStudentList();
            return Ok(response);
        }

        [HttpGet("student/{id}")]
        public async Task<IActionResult> GetStudentDetail(int studentId)
        {

            var response = await _studentService.GetStudentDetail(studentId);
            return Ok(response);
        }
    }
}
