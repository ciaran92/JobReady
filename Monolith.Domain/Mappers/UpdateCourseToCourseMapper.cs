using Monolith.Domain.BusinessObjects;
using Monolith.Domain.Models.Course;

namespace Monolith.Domain.Mappers
{
    public static class UpdateCourseToCourseMapper
    {

        public static Course Map(Course course, UpdateCourseRequest updatedCourse)
        {
            var res = course;
            course.CourseName = updatedCourse.CourseName;
            course.CourseDescription = updatedCourse.CourseDescription;

            return res;
        }
    }
}