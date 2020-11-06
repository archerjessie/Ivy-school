using System;
namespace IvySchool.Domain.Models
{
    public class StudentUser
    {
        public int UserId { get; set; }
        public string Email { get;  set; }
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? LastLoginTime { get; set; }

    }
}
