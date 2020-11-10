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

        #region UserDB
        public async Task CreateUserAsync(UserDb user, RoleDb role)
        {
            _context.Add(user);
            ProcessUserRole(user,role);

            try
            {
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new DBOperationException(ex);
            }
        }

        public IQueryable<UserDb> GetAllActiveUsers()
        {
            return _context.Users
                .Include(user => user.RoleUsers)
                .ThenInclude(userRole => userRole.Role)
                .Where(u => !u.IsDeleted);
        }
        public IQueryable<StudentDb> GetStudents()
        {
            return _context.Students
                .Include(s => s.User)
                .ThenInclude(u => u.SignIns)
                .Where(u => u.User != null && !u.User.IsDeleted);
        }


        public async Task<RoleDb> GetRoleById(int roleId)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == roleId);
        }

        public async Task<UserDb> GetUserByEmail(string email)
        {
            return await _context.Users.Include(user=>user.RoleUsers).FirstOrDefaultAsync(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public async Task AssignRoleToUser(UserDb user, RoleDb role)
        {
            ProcessUserRole(user, role);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new DBOperationException(ex);
            }
        }

        private void ProcessUserRole(UserDb user, RoleDb role)
        {
            RoleUserDb roleUser = new RoleUserDb()
            {
                User = user,
                Role = role
            };
            _context.Add(roleUser);
            if (role.Role == "Student")
            {
                _context.Add(new StudentDb()
                {
                    User = user
                });
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
        #endregion

        #region SignInDb
        public async Task AddSignIn(SigninHistoryDb signin)
        {
            _context.Add(signin);
            try
            {
                await _context.SaveChangesAsync();
   
            }
            catch (Exception ex)
            {
                throw new DBOperationException(ex);
            }
        }

        #endregion

        #region CourseDb
        public async Task CreateCourse(CourseDb course)
        {

            CourseStudentDb courseStudent = new CourseStudentDb()
            {
                Course = course,
            };
            _context.Add(course);

            try
            {
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new DBOperationException(ex);
            }
        }

        public async Task StudentEnrollCourse(int studentId, int courseId)
        {

            CourseStudentDb courseStudent = new CourseStudentDb()
            {
                StudentId = studentId,
                CourseId = courseId,
            };
            if(_context.CourseStudents.Any(x=>x.CourseId==courseId && x.StudentId==studentId))
            {
                return;
            }
            _context.Add(courseStudent);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new DBOperationException(ex);
            }
        }

        public async Task<CourseDb> GetCourseById(int id)
        {
            return await _context.Courses.Include(C=>C.CourseStudents).FirstOrDefaultAsync(x => x.Id== id);
            
        }

        #endregion 

    }
}
