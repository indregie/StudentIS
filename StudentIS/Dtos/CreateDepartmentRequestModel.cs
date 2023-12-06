using StudentIS.Entities;

namespace StudentIS.Dtos
{
    public class CreateDepartmentRequestModel
    {
        public Department? department;
        public List<Student>? students;
    }
}
