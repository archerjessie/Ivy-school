using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IvySchool.Data.Repositories;
using IvySchool.Domain.Models;
using IvySchool.Domain.Responses;
using System.Linq;
using IvySchool.Data.Entities;
using Microsoft.EntityFrameworkCore;
using IvySchool.Data.Entities.Exceptions;

namespace IvySchool.Domain.Services
{
    public class StudentService: IStudentService
    {
        
        private readonly IIvySchoolRepository _ivySchoolRepository;

        public StudentService(IIvySchoolRepository ivySchoolRepository)
        {
            _ivySchoolRepository = ivySchoolRepository;
        }

        public async Task<ObjectResponse<IEnumerable<StudentUser>>> GetStudentList()
        {
            try
            {
                var students = (await _ivySchoolRepository.GetStudents().ToListAsync()).Select(ConvertToStudentUser);
                return ObjectResponse<IEnumerable<StudentUser>>.Success(students);
            }
            catch (DBOperationException ex)
            {
                return ObjectResponse<IEnumerable<StudentUser>>.Error(ex.Message);
            }
        }

        public async Task<ObjectResponse<StudentDetail>> GetStudentDetail(int studentId)
        { 
            try
            {
                var student = await _ivySchoolRepository.GetStudents().FirstOrDefaultAsync();
                return ObjectResponse<StudentDetail>.Success( ConvertToStudentDetail(student));
            }
            catch (DBOperationException ex)
            {
                return ObjectResponse<StudentDetail>.Error(ex.Message);
            }

        }

        private StudentUser ConvertToStudentUser(StudentDb studentDb)
        {
            DateTime? lastSignIn = null;
            if(studentDb.User.SignIns != null && studentDb.User.SignIns.Any())
            {
                lastSignIn = studentDb.User.SignIns.Max(t => t.SigninTime);
            }

            StudentUser student = new StudentUser()
            {
                UserId = studentDb.UserId,
                Email = studentDb.User.Email,
                Name = studentDb.User.Name,
                LastLoginTime = lastSignIn
            };
            return student;
               
        }

        private StudentDetail ConvertToStudentDetail(StudentDb studentDb)
        {
            DateTime? lastSignIn = null;
            if (studentDb.User.SignIns != null && studentDb.User.SignIns.Any())
            {
                lastSignIn = studentDb.User.SignIns.Max(t => t.SigninTime);
            }

            var sortedSigninHistory = studentDb.User.SignIns.OrderBy(s => s.Id);


            StudentDetail student = new StudentDetail()
            {
                StudentId = studentDb.StudentId,
                SignUpSource = studentDb.SignUpSource,
                Notes = studentDb.Notes,
                Avatar = studentDb.Avatar,
                School = studentDb.School,
                Mobile = studentDb.Mobile,
                City = studentDb.City,
                Address = studentDb.Address,
                Title = studentDb.Title,
                CurrentSigninIp = sortedSigninHistory.Count() > 0 ? sortedSigninHistory.TakeLast(1).FirstOrDefault().SigninIp : string.Empty,
                LastSigninIp = sortedSigninHistory.Count() > 1 ? sortedSigninHistory.TakeLast(2).FirstOrDefault().SigninIp : string.Empty,
                NumberOfLogins = studentDb.User.SignIns.Count,
                
            };
            return student;

        }
        
    }
}
