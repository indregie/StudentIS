using StudentIS.Dtos.Request;
using StudentIS.Entities;

namespace StudentIS.Interfaces
{
    public interface ICourseRepository
    {
        Course AddCourse(AddCourseRequestModel req);
        DepartmentCourses AddCourseToDepartment(DepartmentCourses depCourse);
        IEnumerable<Course> CheckCourseExistance(int courseId);
    }
}
