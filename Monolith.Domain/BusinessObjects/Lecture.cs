using System;
using System.Collections.Generic;

namespace Monolith.Domain.BusinessObjects
{
    public class Lecture
    {
        public int Lectureid { get; set; }
        public int Topicid { get; set; }
        public string Lecturename { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
