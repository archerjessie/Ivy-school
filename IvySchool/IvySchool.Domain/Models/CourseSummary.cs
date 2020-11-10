using System;
namespace IvySchool.Domain.Models
{
    public class CourseSummary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Tuition { get; set; }
        public int NumberOfStudent { get; set; }
    }
}
