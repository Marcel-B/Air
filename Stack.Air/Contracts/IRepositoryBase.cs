using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.b_velop.Stack.Air.Contracts
{
    public interface IRepositoryBase<T>
    {
        Task<T> CreateAsync(T entity);
        Task<T> FindAsync(long id);
        Task<T> UpdateAsync(long id, T entity);
        Task<T> DeleteAsync(long id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetByConditionAsync(Func<T, bool> condition);
    }
}
