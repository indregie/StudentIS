using Microsoft.AspNetCore.Mvc;
using StudentIS.Dtos;
using StudentIS.Dtos.Request;
using StudentIS.Entities;
using StudentIS.Exceptions;
using StudentIS.Interfaces;
using StudentIS.Repositories;
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

        [HttpGet]
        public IActionResult GetStudentCourses([FromQuery] int studentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(_studentService.GetStudentCourses(studentId));
            }
            catch (StudentNotFoundException ex)
            {
                _logger.LogWarning("Some warning to prove a concept :) ");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] AddStudentRequestModel req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(_studentService.AddStudent(req));
            }
            catch (DepartmentNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //TO BE IMPLEMENTED when finally understood :)
        //private async Task<IActionResult> HandleErrorsAsync(Func<Task<OkObjectResult>> value)
        //{

        //    return await value();
             
        //}

        [HttpPut]
        public IActionResult UpdateStudentsDepartment([FromQuery] int studentId, [FromQuery] int departmentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(_studentService.UpdateStudentsDepartment(studentId, departmentId));
            }
            catch (StudentNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DepartmentNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
