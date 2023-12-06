using Microsoft.AspNetCore.Mvc;
using StudentIS.Interfaces;

namespace StudentIS.Controllers
{
    [ApiController]
    [Route("Students:[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_studentService.GetStudents());
        }
    }
}
