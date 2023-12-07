using Microsoft.AspNetCore.Http.HttpResults;
using StudentIS.Entities;
using StudentIS.Interfaces;
using StudentIS.Repositories;

namespace StudentIS.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDepartmentService _departmentService;

        public StudentService(IStudentRepository studentRepository, IDepartmentRepository departmentRepository, IDepartmentService departmentService)
        {
            _studentRepository = studentRepository;
            _departmentRepository = departmentRepository;
            _departmentService = departmentService;
        }

        public List<Student> GetStudents()
        {
            return _studentRepository.GetStudents().ToList();
        }

        public List<Course> GetStudentCourses(int studentId)
        {
            return _studentRepository.GetStudentCourses(studentId).ToList();
        }

        public int AddStudent(int departmentId, Student student)
        {
            if (_departmentService.CheckDepartmentExistance(departmentId)) return 1;
            return 0;
        }

    }
}
