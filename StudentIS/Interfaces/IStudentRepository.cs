using StudentIS.Entities;

namespace StudentIS.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
    }
}