using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using IvySchool.Data.Entities;
using IvySchool.Data.Entities.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace IvySchool.Data.Repositories
{
    public class IvySchoolRepository:IIvySchoolRepository
    {
        private readonly IvySchoolContext _context;
        public IvySchoolRepository(IvySchoolContext context)
        {
            _context = context;
        }

        public async Task CreateUserAsync(UserDb user, RoleDb role)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                _context.Add(user);
                RoleUserDb roleUser = new RoleUserDb()
                {
                    User = user,
                    RoleId = role.RoleId
                };
                _context.Add(roleUser);

                try
                {
                    await _context.SaveChangesAsync();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new DBOperationException(ex);
                }
            }
        }

        public IQueryable<UserDb> GetAllActiveUsers()
        {
            return _context.Users
                .Include(user => user.RoleUsers)
                .ThenInclude(userRole => userRole.Role)
                .Where(u=>!u.IsDeleted);
        }

        public async Task<RoleDb> GetRoleById(int roleId)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == roleId);
        }

        public async Task<UserDb> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public async Task AssignRoleToUser(UserDb user, int roleId)
        {
           
            {
                RoleUserDb roleUser = new RoleUserDb()
                {
                    UserId = user.UserId,
                    RoleId = roleId,
                };
                _context.Add(roleUser);

                try
                {
                    await _context.SaveChangesAsync();   
                }
                catch (Exception ex)
                {
                    throw new DBOperationException(ex);
                }
            }
        }

 

        public async Task<bool> UpdateUser(UserDb user)
        {
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
                return true;
            }
            catch(DbUpdateConcurrencyException e)
            {
                if(_context.Users.Any(u=>u.UserId==user.UserId))
                {
                    return false;
                }
                else
                {
                    throw new UserNotExistException(e);
                }
            }
            catch(Exception ex)
            {
                throw new DBOperationException(ex);
            }
        }

       
    }
}
