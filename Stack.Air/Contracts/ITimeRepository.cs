using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.b_velop.Stack.Air.Data.Models;

namespace com.b_velop.Stack.Air.Contracts
{
    public interface ITimeRepository : IRepositoryBase<Time>
    {
        Task<IEnumerable<Time>> GetAllIncludeAsync();
    }
}
