using System.Collections.Generic;
using Monolith.Core.Repositories.Generic;
using Monolith.Domain.BusinessObjects;

namespace Monolith.Core.Repositories
{
    public interface ITopicRepository : IRepositoryBase<Topic>
    {
        bool TopicExists(int topicId);

        List<Topic> GetTopicsForCourse(int courseId);
    }
}