using Monolith.Domain.BusinessObjects;
using Monolith.Domain.Context;

namespace Monolith.Core.Repositories
{
    public class CourseRepository : ICourseRepository<Course>
    {
        private readonly PrimarydbContext _context;
        
        public CourseRepository(PrimarydbContext context)
        {
            _context = context;
        }
        public void Add(Course entity)
        {
            _context.Add(entity);
        }

        public void AddAsync(Course entity)
        {
            _context.AddAsync(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void SaveAsync()
        {
            throw new System.NotImplementedException();
        }

        public Course GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}