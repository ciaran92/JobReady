using Monolith.Domain.BusinessObjects;
using Monolith.Domain.Models.Topic;

namespace Monolith.Domain.Mappers
{
    public static class TopicToTopicDto
    {
        public static TopicDto Map(Topic topic)
        {
            return new TopicDto()
            {
                TopicId = topic.TopicId,
                TopicName = topic.TopicName
            };
        }
    }
}