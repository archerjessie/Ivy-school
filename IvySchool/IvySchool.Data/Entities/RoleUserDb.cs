using System;
namespace IvySchool.Data.Entities
{
    public class RoleUserDb
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public UserDb User{ get; set; }
        public RoleDb Role{ get; set; }
    }
}
