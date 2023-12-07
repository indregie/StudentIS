using StudentIS.Dtos.Request;
using StudentIS.Entities;

namespace StudentIS.Interfaces
{
    public interface ICourseService
    {
        public Course AddCourse(AddCourseRequestModel req);
        DepartmentCourses AddCourseToDepartment(DepartmentCourses depCourse);
        bool CheckCourseExistance(int courseId);
    }
}
