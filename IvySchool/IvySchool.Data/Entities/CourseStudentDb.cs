using System;
namespace IvySchool.Data.Entities
{
    public class CourseStudentDb
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public StudentDb Student { get; set; }
        public CourseDb Course { get; set; }
    }
}
