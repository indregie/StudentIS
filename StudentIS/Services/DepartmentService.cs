using StudentIS.Entities;
using StudentIS.Exceptions;
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

        public int CreateDepartmentStudentsCourses(Department department, List<Student> students, List<Course> courses)
        {
            return _departmentRepository.CreateDepartmentStudentsCourses(department, students, courses);
        }

        public List<Course> GetDepartmentCourses(int departmentId)
        {
            if (!CheckDepartmentExistance(departmentId))
            {
                throw new DepartmentNotFoundException("Department not found.");
            }
            return _departmentRepository.GetDepartmentCourses(departmentId).ToList();
        }

        public List<Student> GetDepartmentStudents(int departmentId)
        {
            if (!CheckDepartmentExistance(departmentId))
            {
                throw new DepartmentNotFoundException("Department not found.");
            }
            return _departmentRepository.GetDepartmentStudents(departmentId).ToList();
        }

        public bool CheckDepartmentExistance(int departmentId)
        {
            List<Department> deps = _departmentRepository.CheckDepartmentExistance(departmentId).ToList();
            if (deps.Count > 0) return true;
            return false;
        }
    }
}
