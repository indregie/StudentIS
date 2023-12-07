using StudentIS.Entities;

namespace StudentIS.Interfaces
{
    public interface IDepartmentRepository
    {
        int CreateDepartmentStudentsCourses(Department department, List<Student> students, List<Course> courses);
        IEnumerable<Course> GetDepartmentCourses(int departmentId);
        IEnumerable<Student> GetDepartmentStudents(int departmentId);
        IEnumerable<Department> CheckDepartmentExistance(int departmentId);
    }
}
