using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IvySchool.Domain.Models;
using IvySchool.Domain.Responses;

namespace IvySchool.Domain.Services
{
    public interface IUserService
    {
        Task<SimpleResponse> CreateUserAsync(string email, string name, string password, int roleId);
        Task<ObjectResponse<User>> LoginUserAsync(string email, string password, string signinIp);
        Task<ObjectResponse<IEnumerable<User>>> GetAdministrators();
    }

}
