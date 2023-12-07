using StudentIS.Entities;

namespace StudentIS.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        IEnumerable<Course> GetStudentCourses(int studentId);
        public Student AddStudent(Student student);
    }
}