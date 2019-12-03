namespace Monolith.Domain.Models.Course
{
    public class CreateCourseResponse
    {
        public bool Success { get; set; }
        public CourseDetailsViewModel CourseViewModel { get; set; }
    }
}