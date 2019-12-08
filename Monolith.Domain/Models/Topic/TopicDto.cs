namespace Monolith.Domain.Models.Topic
{
    public class TopicDto
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public string TopicDescription { get; set; }
        public int TopicOrder { get; set; }
    }
}