using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration;
using Npgsql;
using StudentIS.Entities;
using StudentIS.Interfaces;
using System.Collections.Generic;

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

        //Pridėti studentą į jau egzistuojantį departamentą
        public Student AddStudent(int studentId)
        {
            using (var connection = new NpgsqlConnection("User ID=postgres;Password=115711;Host=localhost;Port=5432;Database=students_is;"))
            {
                string sql = $"insert into students(name, surname, department_id, created, created_by, modified, modified_by) values(@name, @surname, @department_id, @created, @created_by, @modified, @modified_by)"
                var queryArguments = new
                {
                    studentId,
                };

                return connection.QuerySingle<Student>(sql, queryArguments);
            }
        }

    }
}
