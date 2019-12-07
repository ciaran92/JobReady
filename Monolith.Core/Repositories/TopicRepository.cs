using System.Collections.Generic;
using Monolith.Core.Repositories.Generic;
using Monolith.Domain.BusinessObjects;
using Monolith.Domain.Context;
using System.Linq;

namespace Monolith.Core.Repositories
{
    public class TopicRepository : RepositoryBase<Topic>, ITopicRepository
    {
        private readonly PrimarydbContext _context;
        
        public TopicRepository(PrimarydbContext context) : base(context)
        {
            _context = context;
        }

        public bool TopicExists(int topicId)
        {
            return _context.Topic.Any(x => x.TopicId == topicId);
        }

        public List<Topic> GetTopicsForCourse(int courseId)
        {
            var topics = _context.Topic.Where(x => x.CourseId == courseId).ToList();

            return topics;
        }
    }
}