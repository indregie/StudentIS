using Dapper;
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


    }
}
