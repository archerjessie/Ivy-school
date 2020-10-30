using System;
using System.Linq;
using System.Threading.Tasks;
using IvySchool.Data.Entities;

namespace IvySchool.Data.Repositories
{
    public interface IIvySchoolRepository
    {
      
        Task CreateUser(UserDb user, RoleDb role);
        Task<bool> UpdateUser(UserDb user);
        IQueryable<UserDb> GetAllActiveUsers();
        Task<UserDb> GetUserByEmail(string email);
        Task<RoleDb> GetRoleById(int id);
        Task AssignRoleToUser(UserDb user, int roleId);


    }
}
