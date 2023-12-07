using Microsoft.AspNetCore.Http.HttpResults;
using StudentIS.Entities;
using StudentIS.Interfaces;
using StudentIS.Repositories;

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

        public List<Course> GetStudentCourses(int studentId)
        {
            return _studentRepository.GetStudentCourses(studentId).ToList();
        }

    }
}
