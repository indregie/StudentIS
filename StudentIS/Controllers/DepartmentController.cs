using Microsoft.AspNetCore.Mvc;
using StudentIS.Dtos.Request;
using StudentIS.Interfaces;

namespace StudentIS.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class DepartmentController : Controller
    {
        private readonly ILogger<DepartmentController> _logger;

        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService, ILogger<DepartmentController> logger)
        {
            _departmentService = departmentService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult CreateDepartmentStudentsCourses([FromBody] CreateDepartmentRequestModel req)
        {

            return Ok(_departmentService.CreateDepartmentStudentsCourses(
                req.department,
                req.students,
                req.courses
            ));
        }

        [HttpGet]
        public IActionResult GetDepartmentCourses(
            [FromQuery] int departmentId
        )
        {
            Console.WriteLine(departmentId);
            return Ok(_departmentService.GetDepartmentCourses(departmentId));
        }

        [HttpGet]
        public IActionResult GetDepartmentStudents([FromQuery] int departmentId)
        {
            Console.WriteLine(departmentId);
            return Ok(_departmentService.GetDepartmentStudents(departmentId));
        }


    }
}
