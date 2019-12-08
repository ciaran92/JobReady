namespace Monolith.Domain.Models.Topic
{
    public class CreateTopicRequest
    {
        public string TopicName { get; set; }
        public string TopicDescription { get; set; }
        public int TopicOrder { get; set; }
    }
}