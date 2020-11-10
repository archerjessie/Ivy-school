using System;
using System.Collections.Generic;

namespace IvySchool.Data.Entities
{
    public class CourseDb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PrerequisiteKnowledge { get; set; }
        public DateTime CommenceDate { get; set; }
        public DateTime StartAppliedDate { get; set; }
        public DateTime CompleteDate { get; set; }
        public decimal Tuition { get; set; }
        public string Teacher { get; set; }
        public bool Published { get; set; }

        public List<CourseStudentDb> CourseStudents { get; set; }
        public ICollection< AssignmentDb> assignments { get; set; }

    }
}
