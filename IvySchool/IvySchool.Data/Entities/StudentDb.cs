using System;
namespace IvySchool.Data.Entities
{
    public class StudentDb
    {
        public int StudentId { get; set; }
        public string SignUpSource { get; set; }
        public string Notes { get; set; }
        public int UserId { get; set; }
        public int NumberOfLogins { get; set; }
        public string Avatar { get; set; }
        public string School { get; set; }
        public string Mobile { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Title { get; set; }



        public UserDb User { get; set; }
        
    }
}
