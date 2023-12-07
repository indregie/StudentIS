using StudentIS.Dtos.Request;
using StudentIS.Entities;
using StudentIS.Exceptions;
using StudentIS.Interfaces;
using StudentIS.Repositories;

namespace StudentIS.Services
{
    public class CourseService : ICourseService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDepartmentService _departmentService;
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository, IStudentRepository studentRepository, IDepartmentRepository departmentRepository, IDepartmentService departmentService)
        {
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
            _departmentRepository = departmentRepository;
            _departmentService = departmentService;
        }

        public Course AddCourse(AddCourseRequestModel req)
        {
                return _courseRepository.AddCourse(req);
        }

        public bool CheckCourseExistance(int courseId)
        {
            List<Course> courses = _courseRepository.CheckCourseExistance(courseId).ToList();
            if (courses.Count > 0) return true;
            return false;
        }

        public DepartmentCourses AddCourseToDepartment(DepartmentCourses depCourse)
        {
            if (!_departmentService.CheckDepartmentExistance(depCourse.DepartmentId))
            {
                throw new DepartmentNotFoundException("Department not found.");
            }
            if (!CheckCourseExistance(depCourse.CourseId))
            {
                throw new CourseNotFoundException("Course not found.");
            }
            return _courseRepository.AddCourseToDepartment(depCourse);
        }
    }
}
