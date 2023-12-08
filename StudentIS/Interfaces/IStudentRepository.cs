using StudentIS.Dtos.Request;
using StudentIS.Entities;

namespace StudentIS.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Course> GetStudentCourses(int studentId);
        Student AddStudent(AddStudentRequestModel req);
        IEnumerable<Student> CheckStudentExistance(int studentId);
        Student UpdateStudentsDepartment(int studentId, int departmentId);
    }
}