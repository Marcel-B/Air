using System;
using com.b_velop.Stack.Air.Contracts;
using com.b_velop.Stack.Air.Data.Models;
using Microsoft.Extensions.Logging;

namespace com.b_velop.Stack.Air.Data.Repositories
{
    public class TimeRepository : RepositoryBase<Time>, ITimeRepository
    {
        public TimeRepository(IDataContext context, ILogger<RepositoryBase<Time>> logger) : base(context, logger)
        {
        }
    }
}
