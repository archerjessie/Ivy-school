using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IvySchool.Domain.Models;
using IvySchool.Domain.Responses;

namespace IvySchool.Domain.Services
{
    public interface IStudentService
    {
       Task<ObjectResponse<IEnumerable<StudentUser>>> GetStudentList();
        Task<ObjectResponse<StudentDetail>> GetStudentDetail(int studentId);
    }
}
