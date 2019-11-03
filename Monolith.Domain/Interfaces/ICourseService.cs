using Monolith.Domain.BusinessObjects;
using Monolith.Domain.Models.Course;

namespace Monolith.Domain.Interfaces
{
    public interface ICourseService
    {
        CreateCourseResponse CreateCourse(Course course);
    }
}