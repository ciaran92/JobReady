using System;
using System.Collections.Generic;

namespace Monolith.Domain.BusinessObjects
{
    public class Course
    {
        public Course()
        {
            Topic = new HashSet<Topic>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public int? Rating { get; set; }
        public int? InstructorId { get; set; }

        public virtual Appuser Instructor { get; set; }
        public virtual ICollection<Topic> Topic { get; set; }
    }
}
