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

        public int TopicId { get; set; }
        public int CourseId { get; set; }
        public string TopicName { get; set; }
        public string TopicDescription { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int TopicOrder { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<Lecture> Lecture { get; set; }
    }
}
