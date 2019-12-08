using System.Collections.Generic;
using Monolith.Domain.BusinessObjects;
using Monolith.Domain.Models.Topic;

namespace Monolith.Domain.Interfaces
{
    public interface ITopicService
    {
        IEnumerable<TopicDto> GetTopicsForCourse(int courseId);
        bool CreateTopic(int courseId, CreateTopicRequest request);
    }
}