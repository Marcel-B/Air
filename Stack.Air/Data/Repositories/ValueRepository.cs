using System;
using com.b_velop.Stack.Air.Contracts;
using com.b_velop.Stack.Air.Data.Models;
using Microsoft.Extensions.Logging;

namespace com.b_velop.Stack.Air.Data.Repositories
{
    public class ValueRepository : RepositoryBase<Value>, IValueRepository
    {
        public ValueRepository(IDataContext context, ILogger<RepositoryBase<Value>> logger) : base(context, logger)
        {
        }
    }
}
