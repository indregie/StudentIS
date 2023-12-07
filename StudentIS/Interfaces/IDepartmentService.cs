using StudentIS.Entities;

namespace StudentIS.Interfaces
{
    public interface IDepartmentService
    {
        public int CreateDepartmentStudentsCourses(Department department, List<Student> students);
        public List<Course> GetDepartmentCourses(int departmentId);
        public List<Student> GetDepartmentStudents(int departmentId);
    }
}
