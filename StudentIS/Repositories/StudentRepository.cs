using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration;
using Npgsql;
using StudentIS.Entities;
using StudentIS.Interfaces;

namespace StudentIS.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public IEnumerable<Student> GetStudents()
        {
            using (var connection = new NpgsqlConnection("User ID=postgres;Password=115711;Host=localhost;Port=5432;Database=students_is;"))
            {
                return connection.Query<Student>("select * from students");
            }
        }

        //Atvaizduoti visas paskaitas pagal studentą
        public IEnumerable<Course> GetStudentCourses(int studentId)
        {
            using (var connection = new NpgsqlConnection("User ID=postgres;Password=115711;Host=localhost;Port=5432;Database=students_is;"))
            {
                var queryArguments = new
                {
                    studentId,
                };

                return connection.Query<Course>("select * from courses c join course_students cs on cs.course_id = c.id where cs.student_id = @studentId", queryArguments);
            }
        }

    }
}
