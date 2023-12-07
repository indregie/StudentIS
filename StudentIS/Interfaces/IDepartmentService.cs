using StudentIS.Entities;

namespace StudentIS.Interfaces
{
    public interface IDepartmentService
    {
        int CreateDepartmentStudentsCourses(Department department, List<Student> students, List<Course> courses);
        List<Course> GetDepartmentCourses(int departmentId);
        List<Student> GetDepartmentStudents(int departmentId);
        bool CheckDepartmentExistance(int departmentId);
    }
}
