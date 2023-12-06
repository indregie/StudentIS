namespace StudentIS.Entities
{
    public class BaseEntity
    {
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }

        public DateTime Modified { get; set; }
        public string ModifiedBy { get; set;}

        public BaseEntity()
        {
            Created = DateTime.Now;
            CreatedBy = "Indre";
            Modified = DateTime.Now;
            ModifiedBy = "Indre";
        }
    }
}
