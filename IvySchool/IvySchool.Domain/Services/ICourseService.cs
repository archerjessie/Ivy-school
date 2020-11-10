using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IvySchool.Domain.Models;
using IvySchool.Domain.Responses;
namespace IvySchool.Domain.Services
{
    public interface ICourseService
    {
        Task<SimpleResponse> CreateCourseAsync(CourseDetail course);
        Task<SimpleResponse> EnrolledCourse(int studentId, int courseId);
        Task<SimpleResponse> GetCourseDetail(int courseId);
    }
}
