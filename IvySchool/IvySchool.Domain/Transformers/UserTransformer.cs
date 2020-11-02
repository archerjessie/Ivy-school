using System;
using IvySchool.Data.Entities;
using IvySchool.Domain.Models;

namespace IvySchool.Domain.Transformers
{
    public static class UserTransformer
    {
        public static User ToUser(this UserDb userDb)
        {
            User user = new User(userDb.Email, userDb.Name, userDb.CreateAt, userDb.RoleUsers);

            return user;
        }
       
            
    }
}
    
