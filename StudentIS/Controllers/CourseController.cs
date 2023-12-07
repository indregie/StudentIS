using Microsoft.AspNetCore.Mvc;
using StudentIS.Dtos.Request;
using StudentIS.Entities;
using StudentIS.Exceptions;
using StudentIS.Interfaces;
using StudentIS.Services;

namespace StudentIS.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;

        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService, ILogger<CourseController> logger)
        {
            _courseService = courseService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AddCourse([FromBody] AddCourseRequestModel req)
        {
                return Ok(_courseService.AddCourse(req));
        }

        [HttpPost]
        public IActionResult AddCourseToDepartment(DepartmentCourses depCourse)
        {
            try
            {
                var c = _courseService.AddCourseToDepartment(depCourse);
                return Ok(c);
            }
            catch (DepartmentNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (CourseNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
