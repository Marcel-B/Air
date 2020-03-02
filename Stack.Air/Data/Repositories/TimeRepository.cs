using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.b_velop.Stack.Air.Contracts;
using com.b_velop.Stack.Air.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace com.b_velop.Stack.Air.Data.Repositories
{
    public class TimeRepository : RepositoryBase<Time>, ITimeRepository
    {
        public TimeRepository(IDataContext context, ILogger<RepositoryBase<Time>> logger) : base(context, logger)
        {

        }
        public async Task<IEnumerable<Time>> GetAllIncludeAsync()
        {
            //var airs = await _repository.Times.Include("Values").Include("Values.Sensor").ToListAsync();

            return await _context.Times
                //.Include("Values").Include("Values.Sensor")
                .ToListAsync();
        }
    }
}
