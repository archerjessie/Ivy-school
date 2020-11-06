using System;
using System.Collections.Generic;
using System.Linq;
using IvySchool.Data.Entities;

namespace IvySchool.Domain.Models
{
    public class User
    {
        public User(string email, string name,DateTime createAt, List<RoleUserDb> roles)
        {
            Email = email;
            Name = name;
            CreateAt = createAt;
            Roles = roles.Select(r=>r.Role.Role.ToString()).ToList();
            
           
            
        }

        public string Email { get; private set; }
        public string Name{ get;private set; }
        public DateTime CreateAt { get; private set; }
        public List<string> Roles { get; private set; }
        
        
    }
}
