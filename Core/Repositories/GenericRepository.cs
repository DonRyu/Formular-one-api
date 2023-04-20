using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Formular_one_api.Data;
using Microsoft.EntityFrameworkCore;

namespace Formular_one_api.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApiDbContext _context;
        internal DbSet<T> _dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(ApiDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            this._dbSet = _context.Set<T>();
        }
        public virtual async Task<IEnumerable<T>> All()
        {
            // do not track the object
            return await _dbSet.AsNoTracking().ToListAsync();
        }
        public virtual async Task<T?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public virtual async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }
        public virtual async Task<bool> Update(T entity)
        {
            _dbSet.Update(entity);
            return true;
        }
        public virtual async Task<bool> Delete(T entity)
        {
            _dbSet.Remove(entity);
            return true;
        }

    }
}