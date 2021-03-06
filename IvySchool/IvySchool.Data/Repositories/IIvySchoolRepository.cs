﻿using System;
using System.Linq;
using System.Threading.Tasks;
using IvySchool.Data.Entities;

namespace IvySchool.Data.Repositories
{
    public interface IIvySchoolRepository
    {
      
        Task CreateUserAsync(UserDb user, RoleDb role);
        Task<bool> UpdateUser(UserDb user);
        IQueryable<UserDb> GetAllActiveUsers();
        Task<UserDb> GetUserByEmail(string email);
        Task<RoleDb> GetRoleById(int id);
        Task AssignRoleToUser(UserDb user, RoleDb role);
        Task AddSignIn(SigninHistoryDb signin);
        IQueryable<StudentDb> GetStudents();
        Task CreateCourse(CourseDb course);
        Task StudentEnrollCourse(int studentId, int courseId);
        Task<CourseDb> GetCourseById(int id);
      
    }
}
