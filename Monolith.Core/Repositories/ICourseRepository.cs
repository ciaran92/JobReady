using Monolith.Domain.BusinessObjects;

namespace Monolith.Core.Repositories
{
    public interface ICourseRepository<T> where T: class
    {

        void Add(T entity);
        void AddAsync(T entity);
        void Save();
        void SaveAsync();

        T GetById(int id);
    }
}