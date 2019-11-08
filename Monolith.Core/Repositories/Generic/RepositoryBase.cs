using Microsoft.EntityFrameworkCore;
using Monolith.Domain.BusinessObjects;
using Monolith.Domain.Context;

namespace Monolith.Core.Repositories.Generic
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly PrimarydbContext _context;
        private readonly DbSet<T> _dbSet;
        
        public RepositoryBase(PrimarydbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void AddAsync(T entity)
        {
            _dbSet.AddAsync(entity);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public void SaveAsync()
        {
            throw new System.NotImplementedException();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }
    }
}