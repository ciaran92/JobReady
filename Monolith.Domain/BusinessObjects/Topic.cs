using System;
using System.Collections.Generic;

namespace Monolith.Domain.BusinessObjects
{
    public class Topic
    {
        public Topic()
        {
            Lecture = new HashSet<Lecture>();
        }

        public int Topicid { get; set; }
        public int Courseid { get; set; }
        public string Topicname { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<Lecture> Lecture { get; set; }
    }
}
