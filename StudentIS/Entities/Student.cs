namespace StudentIS.Entities
{
    public class Student : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int DepartmentId { get; set; }
    }
}
