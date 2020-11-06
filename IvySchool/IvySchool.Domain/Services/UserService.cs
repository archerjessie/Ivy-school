using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using IvySchool.Data.Entities;
using IvySchool.Data.Entities.Exceptions;
using IvySchool.Data.Repositories;
using IvySchool.Domain.Models;
using IvySchool.Domain.Responses;
using IvySchool.Domain.Transformers;
using Microsoft.EntityFrameworkCore;

namespace IvySchool.Domain.Services
{

    public class UserService : IUserService
    {
        private readonly IIvySchoolRepository _ivySchoolRepository;

        public UserService(IIvySchoolRepository ivySchoolRepository)
        {
            _ivySchoolRepository = ivySchoolRepository;
        }

        public async Task<SimpleResponse> CreateUserAsync(string email, string name, string password, int roleId)
        {
            if (string.IsNullOrEmpty(name))
            {
                return SimpleResponse.Error("Name cannot be empty");
            }

            if (string.IsNullOrEmpty(email) || !IsEmailValid(email))
            {
                return SimpleResponse.Error("Invalid Email format.");
            }

            try
            {
                RoleDb role = await _ivySchoolRepository.GetRoleById(roleId);
                if (role == null)
                {
                    return SimpleResponse.Error("Invalid role id.");
                }


                UserDb user1 = await _ivySchoolRepository.GetUserByEmail(email);
                if (user1 != null)
                {
                    if (user1.RoleUsers.Any(u => u.RoleId == roleId))
                    {
                        return SimpleResponse.Error("User already exists.");
                    }
                    await _ivySchoolRepository.AssignRoleToUser(user1, role);
                }
                else
                {
                    UserDb user2 = new UserDb()
                    {
                        Name = name,
                        Email = email,
                        Password = password,
                        CreateAt = DateTime.Now,
                        IsDeleted = false,

                    };
                    await _ivySchoolRepository.CreateUserAsync(user2, role);
                }
            }
            catch (DBOperationException ex)
            {
                return SimpleResponse.Error(ex.Message);
            }



            return SimpleResponse.Success();
        }


        private bool IsEmailValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public async Task<ObjectResponse<User>> LoginUserAsync(string email, string password,string signinIp)
        {

            UserDb user = await _ivySchoolRepository.GetAllActiveUsers().FirstOrDefaultAsync(e => e.Email == email && e.Password == password);
            if (user == null)
            {
                return ObjectResponse<User>.Error("The user does not exist.");
            }
            SigninHistoryDb signIn = new SigninHistoryDb()
            {
                SigninTime =DateTime.Now,
                SigninIp=signinIp, 
                userId=user.UserId,

            };
            try
            {
                await _ivySchoolRepository.AddSignIn(signIn);
            }
            catch (DBOperationException ex)
            {
                return ObjectResponse<User>.Error(ex.Message);
            }

            return ObjectResponse<User>.Success(user.ToUser());


        }

        public async Task<ObjectResponse<IEnumerable<User>>> GetAdministrators()
        {
            try
            {
                var admins = await _ivySchoolRepository.GetAllActiveUsers()
                    .Where(u => u.RoleUsers.Any(ru => ru.Role.Role == "Admin"))
                    .Select(u=>u.ToUser())
                    .ToListAsync();
                return ObjectResponse<IEnumerable<User>>.Success(admins);
            }
            catch (Exception ex)
            {
                return ObjectResponse<IEnumerable<User>>.Error(ex.Message);
            }
        }
       

    }
}
