using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.b_velop.Stack.Air.Contracts;
using com.b_velop.Stack.Air.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace com.b_velop.Stack.Air.Data.Repositories
{
    public class ValueRepository : RepositoryBase<Value>, IValueRepository
    {
        public ValueRepository(IDataContext context, ILogger<RepositoryBase<Value>> logger) : base(context, logger)
        {
        }

        public async Task<IEnumerable<Value>> GetBySensorIdByHoursAsync(
            long sensorId,
            long hours)
        {
            var result = await _context
                .Values
                .Include("Timestamp")
                .Include("Sensor")
                .Where(_ => _.SensorId == sensorId)
                .Where(_ => _.Timestamp.Timestamp > DateTime.UtcNow.AddHours(-hours))
                .ToListAsync();
            return result;
        }
    }
}
