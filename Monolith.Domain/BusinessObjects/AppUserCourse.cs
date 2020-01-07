using System;
using System.Collections.Generic;
using System.Text;

namespace Monolith.Domain.BusinessObjects
{
    public class AppUserCourse
    {
        public int UserId { get; set; }

        public AppUser AppUser { get; set; }

        public int CourseId { get; set; }

        public Course  Course { get; set; }

    }
}
