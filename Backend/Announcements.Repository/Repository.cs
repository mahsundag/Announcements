using Announcements.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AnnouncementsDbContext _announcumentsDbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(AnnouncementsDbContext announcumentsDbContext)
        {
            _announcumentsDbContext = announcumentsDbContext;
            _dbSet = _announcumentsDbContext.Set<T>();

        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }
        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _dbSet.FindAsync(id);
            if (result is null)
            {
                throw new KeyNotFoundException($"Entity with ID {id} not found.");
            }
            return result;

        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
