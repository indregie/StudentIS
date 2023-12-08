using StudentIS.Entities;

namespace StudentIS.Interfaces
{
    public interface IStudentService
    {
        List<Course> GetStudentCourses(int studentId);
        Student AddStudent(Student student);
        bool CheckStudentExistance(int studentId);
        Student UpdateStudentsDepartment(int studentId, int departmentId);
    }
}