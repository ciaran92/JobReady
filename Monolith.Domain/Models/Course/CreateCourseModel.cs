using System.Collections;
using System.Collections.Generic;
using Monolith.Domain.Models.Topic;

namespace Monolith.Domain.Models.Course
{
    public class CreateCourseModel
    {
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public int? InstructorId { get; set; }
    }
}