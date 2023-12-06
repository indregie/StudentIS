using Microsoft.AspNetCore.Mvc;
using StudentIS.Interfaces;

namespace StudentIS.Controllers
{
    [ApiController]
    [Route("Students:[controller]")]
    public class StudentController : Controller
    {

        private readonly ILogger<StudentController> _logger;

        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService, ILogger<StudentController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            _logger.LogWarning("Some warning");
            return Ok(_studentService.GetStudents());
        }
    }
}
