using System;
using System.Threading.Tasks;
using IvySchool.Data.Repositories;
using IvySchool.Domain.Responses;
using IvySchool.Domain.Models;
using IvySchool.Data.Entities;
using IvySchool.Data.Entities.Exceptions;
using System.Linq;

namespace IvySchool.Domain.Services
{
    public class CourseService:ICourseService
    {
        private readonly IIvySchoolRepository _ivySchoolRepository;

        public CourseService(IIvySchoolRepository ivySchoolRepository)
        {
            _ivySchoolRepository = ivySchoolRepository;
        }

        public async Task<SimpleResponse> CreateCourseAsync(CourseDetail course)
        {
            if (string.IsNullOrEmpty(course.Name))
            {
                return SimpleResponse.Error("Name cannot be empty");
            }
            try
            {
                await _ivySchoolRepository.CreateCourse(ConvertToCourseDb(course));
              
            }
            catch (DBOperationException ex)
            {
                return SimpleResponse.Error(ex.Message);
            }
            return SimpleResponse.Success();

        }

        private CourseDb ConvertToCourseDb(CourseDetail courseDetail)
        {
            CourseDb course = new CourseDb()
            {
                Name = courseDetail.Name,
                PrerequisiteKnowledge = courseDetail.PrerequisiteKnowledge,
                CommenceDate = courseDetail.CommenceDate,
                StartAppliedDate = courseDetail.StartAppliedDate,
                CompleteDate = courseDetail.CompleteDate,
                Tuition = courseDetail.Tuition,
                Published = false

            };
            return course;
        }
        public async Task<SimpleResponse> EnrolledCourse(int studentId, int courseId)
        {
            if (!_ivySchoolRepository.GetStudents().Any(x=>x.StudentId == studentId))

            {
                return SimpleResponse.Error("StudentId cannot be empty");
            }
            if(_ivySchoolRepository.GetCourseById(courseId)==null)
            {
                return SimpleResponse.Error("CourseId cannot be empty");
            }

            try
            {
                await _ivySchoolRepository.StudentEnrollCourse(studentId,courseId);

            }
            catch (DBOperationException ex)
            {
                return SimpleResponse.Error(ex.Message);
            }
            return SimpleResponse.Success();

        }
        public async Task<SimpleResponse> GetCourseDetail(int courseId)
        {
            try
            {
                var course = await _ivySchoolRepository.GetCourseById(courseId);
                return ObjectResponse<CourseDetail>.Success(ConvertToCourseDetail(course));
            }
            catch (DBOperationException ex)
            {
                return SimpleResponse.Error(ex.Message);
            }
               
        }
        private CourseDetail ConvertToCourseDetail(CourseDb courseDb)
        {

            CourseDetail course = new CourseDetail()
            {
                Name = courseDb.Name,
                PrerequisiteKnowledge = courseDb.PrerequisiteKnowledge,
                CommenceDate = courseDb.CommenceDate,
                StartAppliedDate = courseDb.StartAppliedDate,
                CompleteDate = courseDb.CompleteDate,
                Tuition = courseDb.Tuition,
                Published = courseDb.Published,
                NumberOfStudent = courseDb.CourseStudents.Count()
            };
            return course;
        }




    }
}
