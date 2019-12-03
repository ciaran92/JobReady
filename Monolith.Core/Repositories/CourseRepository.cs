using System.Collections.Generic;
using System.Linq;
using Monolith.Core.Repositories.Generic;
using Monolith.Domain.BusinessObjects;
using Monolith.Domain.Context;

namespace Monolith.Core.Repositories
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        private readonly PrimarydbContext _context;
        
        public CourseRepository(PrimarydbContext context) : base(context)
        {
            _context = context;
        }

        public bool CourseExists(int courseId)
        {
            return _context.Course.Any(x => x.CourseId == courseId);
        }

        public List<Course> GetAllCourses(int instructorId)
        {
            return _context.Course.Where(c => c.InstructorId == instructorId).ToList();
        }
    }
}