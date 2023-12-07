using StudentIS.Entities;

namespace StudentIS.Interfaces
{
    public interface IDepartmentRepository
    {
        public int CreateDepartmentStudentsCourses(Department department, List<Student> students);
        public IEnumerable<Course> GetDepartmentCourses(int departmentId);
        public IEnumerable<Student> GetDepartmentStudents(int departmentId);
        public IEnumerable<Department> CheckDepartmentExistance(int departmentId);
    }
}
