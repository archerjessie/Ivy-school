using System;
using System.Collections.Generic;
using IvySchool.Data.Entities;

namespace IvySchool.Domain.Models
{
    public class User
    {
        public User(string name,
            int userId,
            string email,
            string password,
            bool isDeleted,
            DateTime createAt,
            int roleId)
        {
            UserId = userId;
            Name = name;
            Email = email;
            Password = password;
            IsDeleted = isDeleted;
            CreateAt = createAt;
            RoleId = roleId;

        }

        public int UserId { get; private set;}
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreateAt { get; private set; }
        public int RoleId { get; private set;}
    }
}
