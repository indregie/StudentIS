namespace StudentIS.Entities
{
    public class DepartmentCourses
    {
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid CoursesId { get; set; }
    }
}
