using StudentIS.Entities;
using StudentIS.Interfaces;

namespace StudentIS.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }



        public int CreateDepartmentStudentsCourses(Department department, List<Student> students)
        {
            return _departmentRepository.CreateDepartmentStudentsCourses(department, students);
        }

        public List<Course> GetDepartmentCourses(int departmentId)
        {
            return _departmentRepository.GetDepartmentCourses(departmentId).ToList();
        }

        public List<Student> GetDepartmentStudents(int departmentId)
        {
            return _departmentRepository.GetDepartmentStudents(departmentId).ToList();
        }
    }
}
