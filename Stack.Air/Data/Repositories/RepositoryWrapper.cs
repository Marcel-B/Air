using System;
using System.Threading.Tasks;
using com.b_velop.Stack.Air.Contracts;
using Microsoft.Extensions.Logging;

namespace com.b_velop.Stack.Air.Data.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IDataContext _context;
        private ILogger<RepositoryWrapper> _logger;

        public RepositoryWrapper(
            IDataContext context,
            ISensorRepository sensorRepository,
            ITimeRepository timeRepository,
            IValueRepository valueRepository,
            ILogger<RepositoryWrapper> logger)
        {
            _context = context;
            Sensors = sensorRepository;
            Times = timeRepository;
            Values = valueRepository;
            _logger = logger;
        }

        public IValueRepository Values { get; }
        public ITimeRepository Times { get; }
        public ISensorRepository Sensors { get; }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(6666, ex, $"Error occurred while save DataContext");
                return -1;
            }
        }
    }
}
