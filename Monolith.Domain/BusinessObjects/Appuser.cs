using System;
using System.Collections.Generic;

namespace Monolith.Domain.BusinessObjects
{
    public class Appuser
    {
        public Appuser()
        {
            Course = new HashSet<Course>();
        }

        public int Userid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Instructorrating { get; set; }
        
        public string Salt { get; set; }
        public bool Isapproved { get; set; }

        public virtual ICollection<Course> Course { get; set; }
    }
}
