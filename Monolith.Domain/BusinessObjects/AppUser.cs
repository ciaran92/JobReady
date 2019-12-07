using System;
using System.Collections.Generic;

namespace Monolith.Domain.BusinessObjects
{
    public class AppUser
    {
        public AppUser()
        {
            Course = new HashSet<Course>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? InstructorRating { get; set; }
        
        public string Salt { get; set; }
        public bool IsApproved { get; set; }

        public virtual ICollection<Course> Course { get; set; }
    }
}
