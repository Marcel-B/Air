using System;
using com.b_velop.Stack.Air.Contracts;
using com.b_velop.Stack.Air.Data.Models;
using Microsoft.Extensions.Logging;

namespace com.b_velop.Stack.Air.Data.Repositories
{
    public class SensorRepository : RepositoryBase<Sensor>, ISensorRepository
    {
        public SensorRepository(IDataContext context, ILogger<RepositoryBase<Sensor>> logger) : base(context, logger)
        {
        }
    }
}
