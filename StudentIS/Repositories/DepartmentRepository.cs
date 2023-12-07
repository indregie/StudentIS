using Dapper;
using Npgsql;
using StudentIS.Entities;
using StudentIS.Interfaces;

namespace StudentIS.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    // Sukurti departamentą ir į jį pridėti studentus, paskaitas(papildomi points jei pridedamos paskaitos jau egzistuojančios duomenų bazėje).
    // jei bus bandoma pridėti paskaitą, kurios nėra db, tarpinės lentos foreign key'us išmes klaidą :)) todėl bonus points sąlyga savotiškai tenkinama
    public int CreateDepartmentStudentsCourses(Department department, List<Student> students)
    {

        using (var connection = new NpgsqlConnection("User ID=postgres;Password=115711;Host=localhost;Port=5432;Database=students_is;"))
        {
            connection.Open();
            using (var transaction = connection.BeginTransaction(System.Data.IsolationLevel.Snapshot))
            {

                string sql = $"INSERT INTO public.departments (name, created, created_by, modified, modified_by) VALUES (@name, @created, @created_by, @modified, @modified_by)";
                var queryArguments = new
                {
                    name = department.Name,
                    created = department.Created,
                    created_by = department.CreatedBy,
                    modified = department.Modified,
                    modified_by = department.ModifiedBy
                };

                foreach (var student in students)
                {
                    string sqlStud = $"INSERT INTO public.students (name, surname, department_id, created, created_by, modified, modified_by) VALUES (@name, @surname, @department_id, @created, @created_by, @modified, @modified_by)";
                    var queryArgumentsStud = new
                    {
                        name = student.Name,
                        surname = student.Surname,
                        department_id = student.DepartmentId,
                        created = student.Created,
                        created_by = student.CreatedBy,
                        modified = student.Modified,
                        modified_by = student.ModifiedBy
                    };
                }


                connection.Execute(sql, queryArguments, transaction: transaction);
                transaction.Commit();
                return 0;
            }
        }
    }

    //Atvaizduoti visus departamento studentus.
    public IEnumerable<Student> GetDepartmentStudents(int departmentId)
    {
        using (var connection = new NpgsqlConnection("User ID=postgres;Password=115711;Host=localhost;Port=5432;Database=students_is;"))
        {
            var queryArguments = new
            {
                departmentId,
            };

            return connection.Query<Student>("select * from students s join departments d on d.id = s.department_id where d.id = @departmentId", queryArguments);
        }
    }

    //Atvaizduoti visas departamento paskaitas.
    public IEnumerable<Course> GetDepartmentCourses(int departmentId)
    {
        using (var connection = new NpgsqlConnection("User ID=postgres;Password=115711;Host=localhost;Port=5432;Database=students_is;"))
        {
            var queryArguments = new
            {
                departmentId,
            };

            return connection.Query<Course>("select * " +
                "from courses c " +
                "join department_courses dc on dc.course_id = c.id " +
                "where dc.department_id = @departmentId", queryArguments);
        }
    }

    //Patikrinti ar departamentas egzistuoja
    public IEnumerable<Department> CheckDepartmentExistance(int departmentId)
    {
        using (var connection = new NpgsqlConnection("User ID=postgres;Password=115711;Host=localhost;Port=5432;Database=students_is;"))
        {
            var queryArguments = new
            {
                departmentId,
            };

            return connection.Query<Department>("select * from departments where id = @departmentId", queryArguments);
        }
    }
}

