using StudentIS.Dtos.Request;
using StudentIS.Entities;

namespace StudentIS.Interfaces
{
    public interface IStudentService
    {
        List<Course> GetStudentCourses(int studentId);
        Student AddStudent(AddStudentRequestModel req);
        bool CheckStudentExistance(int studentId);
        Student UpdateStudentsDepartment(int studentId, int departmentId);
    }
}