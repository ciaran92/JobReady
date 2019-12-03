using System.Collections.Generic;
using Monolith.Domain.BusinessObjects;
using Monolith.Domain.Models.Course;
using Monolith.Domain.Models.Topic;

namespace Monolith.Domain.Interfaces
{
    public interface ICourseService
    {
        CreateCourseResponse CreateCourse(Course course);
        CourseDetailsViewModel GetCourseDetails(int courseId);
        Course GetCourse(int courseId);
        List<CourseListViewModel> GetOwnedCourses(int userId);
        List<TopicDto> GetTopics(int courseId);
        bool UpdateCourse(Course course, UpdateCourseRequest changes);
    }
}