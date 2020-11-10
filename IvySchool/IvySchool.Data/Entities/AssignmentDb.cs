using System;
using System.Collections.Generic;

namespace IvySchool.Data.Entities
{
    public class AssignmentDb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public CourseDb Course {get;set;}
    }
}
