using System;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using IvySchool.Data.Entities;
using IvySchool.Data.Entities.Exceptions;
using IvySchool.Data.Repositories;
using IvySchool.Domain.Models;
using IvySchool.Domain.Responses;
using IvySchool.Domain.Transformers;

namespace IvySchool.Domain.Services
{
   
    public class UserService : IUserService
    { 
        private readonly IIvySchoolRepository _ivySchoolRepository;
    
        public UserService(IIvySchoolRepository ivySchoolRepository)
        {
            _ivySchoolRepository = ivySchoolRepository;
        }

        public async Task<SimpleResponseObject> CreateUserAsync(User user)
        {
            if (string.IsNullOrEmpty(user.Name))
            {
                return SimpleResponseObject.Error("Name cannot be empty");
            }

            if (string.IsNullOrEmpty(user.Email)|| !IsEmailValid(user.Email))
            {
                return SimpleResponseObject.Error("Invalid Email format.");
            }

            try
            {
                RoleDb role = await _ivySchoolRepository.GetRoleById(user.RoleId);
                if(role == null)
                {
                    return SimpleResponseObject.Error("Invalid role id.");
                }
              
                
                    UserDb user1 = await _ivySchoolRepository.GetUserByEmail(user.Email);
                if (user1 != null)
                {
                    if (user1.RoleUsers.Any(u => u.RoleId == user.RoleId))
                    {
                        return SimpleResponseObject.Error("User already exists.");
                    }
                    await _ivySchoolRepository.AssignRoleToUser(user.ToUserDb(), user.RoleId);
                }
                else
                {
                    var userDb = user.ToUserDb();
                    userDb.CreateAt = DateTime.Now;
                    userDb.IsDeleted = false;
                    await _ivySchoolRepository.CreateUserAsync(userDb, role);
                }


            }
            catch(DBOperationException ex)
            {
                return SimpleResponseObject.Error(ex.Message);
            }

           

            return SimpleResponseObject.Success();
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


    }
}
