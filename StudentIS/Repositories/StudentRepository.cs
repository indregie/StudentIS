using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration;
using Npgsql;
using StudentIS.Entities;
using StudentIS.Interfaces;
using System.Collections.Generic;
using System.Data;

namespace StudentIS.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDbConnection _connection;

        public StudentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Student> GetStudents()
        {

                return _connection.Query<Student>("select * from students");

        }

        //Atvaizduoti visas paskaitas pagal studentą
        public IEnumerable<Course> GetStudentCourses(int studentId)
        {

                var queryArguments = new
                {
                    studentId,
                };

                return _connection.Query<Course>("select * from courses c join course_students cs on cs.course_id = c.id where cs.student_id = @studentId", queryArguments);
            
        }

        //Pridėti studentą į jau egzistuojantį departamentą
        public Student AddStudent(Student student)
        {

                string sql = $"insert into students(name, surname, department_id, created, created_by, modified, modified_by) values(@name, @surname, @department_id, @created, @created_by, @modified, @modified_by)";
                var queryArguments = new
                {
                    name = student.Name,
                    surname = student.Surname,
                    department = student.DepartmentId,
                    created = student.Created,
                    created_by = student.CreatedBy,
                    modified = student.Modified,
                    modified_by = student.ModifiedBy
                };

                return _connection.QuerySingle<Student>(sql, queryArguments);
            
        }

    }
}
