using StudentIS.Entities;

namespace StudentIS.Interfaces
{
    public interface IStudentService
    {
        List<Student> GetStudents();
    }
}