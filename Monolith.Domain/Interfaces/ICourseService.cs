using System.Collections.Generic;
using System.Threading.Tasks;
using Monolith.Domain.BusinessObjects;
using Monolith.Domain.Models.Course;
using Monolith.Domain.Models.Topic;

namespace Monolith.Domain.Interfaces
{
    public interface ICourseService
    {
        CreateCourseResponse CreateCourse(Course course);
        CourseDetailsViewModel GetCourseDetails(int courseId);
        Course GetCourseForInstructor(int instructorId, int courseId);
        List<CourseListViewModel> GetOwnedCourses(int userId);
        bool UpdateCourse(Course course, CourseForUpdateDto changes);

        Task<Course> GetCourseByIdAsync(int courseId);
        Task<bool> CreateEnrolmentAsync(AppUserCourse enrolment);
        Task<bool> StudentEnrolledInCourseAsync(int courseId, int userId);
    }
}