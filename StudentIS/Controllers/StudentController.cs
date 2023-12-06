using Microsoft.AspNetCore.Mvc;
using StudentIS.Dtos;
using StudentIS.Entities;
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

        //perdaryti async
        //[HttpGet]
        //public IActionResult GetStudents()
        //{
        //    _logger.LogWarning("Some warning");
        //    return Ok(_studentService.GetStudents());
        //}




        [HttpPost]
        public IActionResult CreateDepartmentStudentsCourses(
            [FromBody] CreateDepartmentRequestModel req 
        )
        {
            return Ok(_studentService.CreateDepartmentStudentsCourses(
                req.department,
                req.students
            ));
        }

        [HttpGet]
        public IActionResult GetDepartmentCourses(
            [FromQuery] int departmentId   
        )
        {
            Console.WriteLine(departmentId);
            return Ok(_studentService.GetDepartmentCourses(departmentId));
        }
    }
}
