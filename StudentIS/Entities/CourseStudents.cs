﻿namespace StudentIS.Entities
{
    public class CourseStudents : BaseEntity
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
    }
}
