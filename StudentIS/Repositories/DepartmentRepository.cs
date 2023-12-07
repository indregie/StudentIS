using Dapper;
using Npgsql;
using StudentIS.Entities;
using StudentIS.Interfaces;
using System.Data;

namespace StudentIS.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly IDbConnection _connection;

    public DepartmentRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    // Sukurti departamentą ir į jį pridėti studentus, paskaitas(papildomi points jei pridedamos paskaitos jau egzistuojančios duomenų bazėje).
    public int CreateDepartmentStudentsCourses(Department department, List<Student> students, List<Course> courses)
    {
        _connection.Open();
        using (var transaction = _connection.BeginTransaction(System.Data.IsolationLevel.Snapshot))
        {

            string sql = $"INSERT INTO public.departments " +
            $"(name, created, created_by, modified, modified_by)" +
            $" VALUES (@name, @created, @created_by, @modified, @modified_by) returning id as Id";
            var queryArguments = new
            {
                name = department.Name,
                created = department.Created,
                created_by = department.CreatedBy,
                modified = department.Modified,
                modified_by = department.ModifiedBy
            };
            int depId = _connection.QuerySingle<int>(sql, queryArguments, transaction: transaction);

            foreach (var student in students)
            {
                string sqlStud = $"INSERT INTO public.students (name, surname, department_id, created, created_by, modified, " +
                    $"modified_by) VALUES (@name, @surname, @department_id, @created, @created_by, @modified, @modified_by)";
                var queryArgumentsStud = new
                {
                    name = student.Name,
                    surname = student.Surname,
                    department_id = depId,
                    created = student.Created,
                    created_by = student.CreatedBy,
                    modified = student.Modified,
                    modified_by = student.ModifiedBy
                };
                _connection.Execute(sqlStud, queryArgumentsStud, transaction: transaction);
            }

            foreach (var course in courses)
            {
                string sqlCourse = $"INSERT INTO public.courses (name, created, created_by, modified, modified_by)" +
                    $" VALUES (@name, @created, @created_by, @modified, @modified_by) returning id as Id";
                var queryArgumentsCourse = new
                {
                    name = course.Name,
                    created = course.Created,
                    created_by = course.CreatedBy,
                    modified = course.Modified,
                    modified_by = course.ModifiedBy
                };
                int courseId = _connection.Execute(sqlCourse, queryArgumentsCourse, transaction: transaction);

                string sqlDepCourse = $"INSERT INTO public.department_courses (department_id, course_id, created, created_by," +
                    $" modified, modified_by) VALUES (@department_id, @course_id, @created, @created_by, @modified, @modified_by)";
                var queryArgumentsDepCourse = new
                {
                    department_id = depId,
                    course_id = courseId,
                    created = course.Created,
                    created_by = course.CreatedBy,
                    modified = course.Modified,
                    modified_by = course.ModifiedBy
                };
                _connection.Execute(sqlDepCourse, queryArgumentsDepCourse, transaction: transaction);
            }

            transaction.Commit();
            return 0;
        }

    }

    //Atvaizduoti visus departamento studentus.
    public IEnumerable<Student> GetDepartmentStudents(int departmentId)
    {
        var queryArguments = new
        {
            departmentId,
        };

        return _connection.Query<Student>("select * from students s join departments d on d.id = s.department_id where d.id = @departmentId", queryArguments);
    }

    //Atvaizduoti visas departamento paskaitas.
    public IEnumerable<Course> GetDepartmentCourses(int departmentId)
    {

        var queryArguments = new
        {
            departmentId,
        };

        return _connection.Query<Course>("select * " +
            "from courses c " +
            "join department_courses dc on dc.course_id = c.id " +
            "where dc.department_id = @departmentId", queryArguments);
    }

    //Patikrinti ar departamentas egzistuoja
    public IEnumerable<Department> CheckDepartmentExistance(int departmentId)
    {
        var queryArguments = new
        {
            departmentId,
        };

        return _connection.Query<Department>("select * from departments where id = @departmentId", queryArguments);
    }
}

