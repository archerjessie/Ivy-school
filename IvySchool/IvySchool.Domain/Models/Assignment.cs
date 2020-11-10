using System;
using IvySchool.Data.Entities;

namespace IvySchool.Domain.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public CourseDb Course { get; set; }
    }
}
