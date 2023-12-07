using Microsoft.AspNetCore.Mvc;

namespace StudentIS.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class CourseController : Controller
    {
        [HttpPost]
        public IActionResult CreateNewCourse()
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult AddStudentToDepartment()
        {
            return Ok();
        }
    }
}
