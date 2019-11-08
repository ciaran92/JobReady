namespace Monolith.Core.Repositories.Generic
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);
        void AddAsync(T entity);
        bool Save();
        void SaveAsync();
        T GetById(int id);
    }
}