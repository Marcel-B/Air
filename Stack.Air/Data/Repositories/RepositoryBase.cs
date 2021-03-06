﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.b_velop.Stack.Air.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace com.b_velop.Stack.Air.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected IDataContext _context;
        protected ILogger<RepositoryBase<T>> _logger;

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

        public async Task<T> FindAsync(
            long id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetByConditionAsync(
            Func<T, bool> condition)
        {
            var values = _context.Set<T>().Where(condition);
            return await Task.FromResult(values);
        }

        public Task<T> UpdateAsync(long id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
