using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.b_velop.Stack.Air.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace com.b_velop.Stack.Air.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private IDataContext _context;
        private ILogger<RepositoryBase<T>> _logger;

        public RepositoryBase(
            IDataContext context,
            ILogger<RepositoryBase<T>> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<T> CreateAsync(
            T entity)
        {
            var e = await _context.Set<T>().AddAsync(entity);
            return e.Entity;
        }

        public async Task<T> DeleteAsync(
            long id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            var result = _context.Set<T>().Remove(entity);
            return result.Entity;
        }

        public Task<T> FindAsync(
            long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public Task<IEnumerable<T>> GetByConditionAsync(Func<T, bool> condition)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(long id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
