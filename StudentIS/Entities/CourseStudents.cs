namespace StudentIS.Entities
{
    public class CourseStudents : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
    }
}
