using System;
using IvySchool.Data.Entities;
using IvySchool.Domain.Models;

namespace IvySchool.Domain.Transformers
{
    public static class UserTransformer
    {
        public static UserDb ToUserDb(this User user)
        {
            UserDb userDb = new UserDb()
            {
                UserId = user.UserId,
                Name=user.Name,
                Email = user.Email,
                Password = user.Password,
                IsDeleted = user.IsDeleted,
                CreateAt = user.CreateAt,
            };
            return userDb;
        }
    }
}
    
