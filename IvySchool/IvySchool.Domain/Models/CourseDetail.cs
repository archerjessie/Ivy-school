using System;
namespace IvySchool.Domain.Models
{
    public class CourseDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PrerequisiteKnowledge { get; set; }
        public DateTime CommenceDate { get; set; }
        public DateTime StartAppliedDate { get; set; }
        public DateTime CompleteDate { get; set; }
        public decimal Tuition { get; set; }
        public bool Published { get; set; }
        public int NumberOfStudent { get; set; }

    }
}
