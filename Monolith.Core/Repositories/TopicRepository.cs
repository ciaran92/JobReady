using Monolith.Core.Repositories.Generic;
using Monolith.Domain.BusinessObjects;
using Monolith.Domain.Context;

namespace Monolith.Core.Repositories
{
    public class TopicRepository : RepositoryBase<Topic>, ITopicRepository
    {
        private readonly PrimarydbContext _context;
        
        public TopicRepository(PrimarydbContext context) : base(context)
        {
            _context = context;
        }
    }
}