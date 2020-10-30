using System;
using System.Threading.Tasks;
using IvySchool.Domain.Models;
using IvySchool.Domain.Responses;

namespace IvySchool.Domain.Services
{
    public interface IUserService
    {
        Task<SimpleResponseObject> CreateUserAsync(User user);
    }

}
