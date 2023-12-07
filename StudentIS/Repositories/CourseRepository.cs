using Dapper;
using StudentIS.Dtos.Request;
using StudentIS.Entities;
using StudentIS.Interfaces;
using System.Data;

namespace StudentIS.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IDbConnection _connection;

        public CourseRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        //Pridėti kursa
        public Course AddCourse(AddCourseRequestModel req)
        {
            var course = new Course();
            string sql = $"insert into courses(name, created, created_by, modified, modified_by)" +
                $" values(@name, @created, @created_by, @modified, @modified_by) returning id as Id, name as Name";
            var queryArguments = new
            {
                name = req.Name,
                created = course.Created,
                created_by = course.CreatedBy,
                modified = course.Modified,
                modified_by = course.ModifiedBy
            };

            return _connection.QuerySingle<Course>(sql, queryArguments);
        }

        //Pridėti kursa i egzistuojanti departamenta
        public DepartmentCourses AddCourseToDepartment(DepartmentCourses depCourse)
        {
            string sql = $"insert into department_courses(" +
                $"department_id, course_id, created, created_by, modified, modified_by) " +
                $"values(@department_id, @course_id, @created, @created_by, @modified, @modified_by) " +
                $"returning department_id as DepartmentId, course_id as CourseId";
            var queryArguments = new
            {
                department_id = depCourse.DepartmentId,
                course_id = depCourse.CourseId,
                created = depCourse.Created,
                created_by = depCourse.CreatedBy,
                modified = depCourse.Modified,
                modified_by = depCourse.ModifiedBy
            };
            var c = _connection.QuerySingle<DepartmentCourses>(sql, queryArguments);
            return c;

        }

        //Patikrinti ar kursas egzistuoja
        public IEnumerable<Course> CheckCourseExistance(int courseId)
        {
            var queryArguments = new
            {
                courseId,
            };

            return _connection.Query<Course>("select * from courses where id = @courseId", queryArguments);
        }
    }
}
