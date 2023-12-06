using Microsoft.AspNetCore.Http.HttpResults;
using StudentIS.Entities;
using StudentIS.Interfaces;

namespace StudentIS.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public List<Student> GetStudents()
        {
            return _studentRepository.GetStudents().ToList();
        }

    
        public int CreateDepartmentStudentsCourses(Department department, List<Student> students)
        {
            return _studentRepository.CreateDepartmentStudentsCourses(department, students);
        }

        public List<Course> GetDepartmentCourses(int departmentId)
        {
            return _studentRepository.GetDepartmentCourses(departmentId).ToList();
        }
    }
}
