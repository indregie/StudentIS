namespace StudentIS.Entities
{
    public class DepartmentCourses : BaseEntity
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
    }
}
