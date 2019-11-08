using Monolith.Core.Repositories.Generic;
using Monolith.Domain.BusinessObjects;
using Monolith.Domain.Context;

namespace Monolith.Core.Repositories
{
    public class LectureRepository : RepositoryBase<Lecture>, ILectureRepository
    {
        private readonly PrimarydbContext _context;
        
        public LectureRepository(PrimarydbContext context) : base(context)
        {
            _context = context;
        }
        
    }
}