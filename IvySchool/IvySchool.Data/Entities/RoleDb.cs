using System;
using System.Collections.Generic;

namespace IvySchool.Data.Entities
{
    public class RoleDb
    {
        public int RoleId { get; set; }
        public string Role { get; set; }
        public List<RoleUserDb> RoleUsers { get; set; }

        public static implicit operator int(RoleDb v)
        {
            throw new NotImplementedException();
        }
    }
}
