using Microsoft.AspNetCore.Mvc;
using StudentIS.Dtos;
using StudentIS.Entities;
using StudentIS.Interfaces;
using StudentIS.Services;

namespace StudentIS.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class StudentController : Controller
    {

        private readonly ILogger<StudentController> _logger;

        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService, ILogger<StudentController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }

        //perdaryti async
        [HttpGet]
        public IActionResult GetStudents()
        {
            _logger.LogWarning("Some warning");
            return Ok(_studentService.GetStudents());
        }

        [HttpGet]
        public IActionResult GetStudentCourses(
                [FromQuery] int studentId
            )
        {
            return Ok(_studentService.GetStudentCourses(studentId));
        }




    }
}
