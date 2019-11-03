namespace Monolith.Domain.Models.Course
{
    public class CreateCourseResponse
    {
        public bool Success { get; set; }
        public CourseViewModel CourseViewModel { get; set; }
    }
}