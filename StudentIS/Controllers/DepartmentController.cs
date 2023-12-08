using Microsoft.AspNetCore.Mvc;
using StudentIS.Dtos.Request;
using StudentIS.Exceptions;
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_departmentService.CreateDepartmentStudentsCourses(
                req.department,
                req.students,
                req.courses
            ));
        }

        [HttpGet]
        public IActionResult GetDepartmentCourses([FromQuery] int departmentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(_departmentService.GetDepartmentCourses(departmentId));
            }
            catch (DepartmentNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetDepartmentStudents([FromQuery] int departmentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(_departmentService.GetDepartmentStudents(departmentId));
            }
            catch (DepartmentNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
