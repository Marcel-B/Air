using System.Collections.Generic;
using System.Threading.Tasks;
using com.b_velop.Stack.Air.Contracts;
using com.b_velop.Stack.Air.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace com.b_velop.Stack.Air.Data.Repositories
{
    public class SensorRepository : RepositoryBase<Sensor>, ISensorRepository
    {
        public SensorRepository(IDataContext context, ILogger<RepositoryBase<Sensor>> logger) : base(context, logger) { }

        public async Task<IEnumerable<Sensor>> GetAllIncludeAsync()
        {
            var sensors = await _context.Sensors.Include(_ => _.ValueType).ToListAsync();
            return sensors;
        }
    }
}
