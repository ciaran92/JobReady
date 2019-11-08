using System.ComponentModel.DataAnnotations;

namespace Monolith.Domain.Models.Course
{
    public class UpdateCourseRequest
    {
        [Required(ErrorMessage = "Course Name is required")]
        [MaxLength(255, ErrorMessage = "Course Name can have no more than 255 characters")]
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        //public int? InstructorId { get; set; }
    }
}