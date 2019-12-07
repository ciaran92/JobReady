using System;
using System.Collections.Generic;

namespace Monolith.Domain.BusinessObjects
{
    public class Lecture
    {
        public int LectureId { get; set; }
        public int TopicId { get; set; }
        public string LectureName { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
