using StudentIS.Entities;

namespace StudentIS.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        public int CreateDepartmentStudentsCourses(Department department, List<Student> students);
        public IEnumerable<Course> GetDepartmentCourses(int departmentId);
    }
}