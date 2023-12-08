using Microsoft.AspNetCore.Http.HttpResults;
using StudentIS.Entities;
using StudentIS.Exceptions;
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

        public List<Course> GetStudentCourses(int studentId)
        {
            if (CheckStudentExistance(studentId))
            {
                return _studentRepository.GetStudentCourses(studentId).ToList();
            }
            throw new StudentNotFoundException("Student not found.");
        }

        public Student AddStudent(Student student)
        {
            if (_departmentService.CheckDepartmentExistance(student.DepartmentId))
            {
                return _studentRepository.AddStudent(student);
               
            }
            throw new DepartmentNotFoundException("Department not found.");
        }

        public bool CheckStudentExistance(int studentId)
        {
            List<Student> students = _studentRepository.CheckStudentExistance(studentId).ToList();
            if (students.Count > 0) return true;
            return false;
        }

        public Student UpdateStudentsDepartment(int studentId, int departmentId)
        {
            if (!CheckStudentExistance(studentId))
            {
                throw new StudentNotFoundException("Student not found.");
            }
            if (!_departmentService.CheckDepartmentExistance(departmentId) )
            {
                throw new DepartmentNotFoundException("Department not found.");
            }
            return _studentRepository.UpdateStudentsDepartment(studentId, departmentId);
        }

    }
}
