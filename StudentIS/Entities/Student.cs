namespace StudentIS.Entities
{
    public class Student : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Department Department { get; set; }
    }
}
