using StudentIS.Entities;
using System.Text.Json;
namespace StudentIS.Dtos.Request
{
    public class CreateDepartmentRequestModel
    {
        public Department department { get; set; }
        public List<Student> students { get; set; }
        public List<Course> courses { get; set; }
    }
}
