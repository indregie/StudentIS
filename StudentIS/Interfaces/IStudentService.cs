using StudentIS.Entities;

namespace StudentIS.Interfaces
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        //public int CreateDepartmentStudentsCourses(Department department, List<Student> students);
        //public List<Course> GetDepartmentCourses(int departmentId);
        List<Course> GetStudentCourses(int studentId);
    }
}