using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.b_velop.Stack.Air.Contracts;
using com.b_velop.Stack.Air.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace com.b_velop.Stack.Air.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IStatisticProvider _statisticProvider;
        private ILogger<StatsController> _logger;

        public StatsController(
            IRepositoryWrapper repository,
            IStatisticProvider statisticProvider,
            ILogger<StatsController> logger)
        {
            _repository = repository;
            _statisticProvider = statisticProvider;
            _logger = logger;
        }

        [HttpGet("{hours}")]
        public async Task<IActionResult> GetStatisticAsync(
            long hours)
        {
            var sensors = await _repository.Sensors.GetAllAsync();
            var results = new HashSet<Statistic>();
            foreach (var sensor in sensors)
            {
                var values = await _repository.Values.GetBySensorIdByHoursAsync(sensor.Id, hours);
                if (values == null || values.Count() == 0)
                    return BadRequest($"No {sensor.Name} values for the last {hours} hours in database");
                var stats = await _statisticProvider.GetStatistic(values.Select(_ => _.MeasureValue));
                stats.Name = sensor.Name;
                results.Add(stats);
            }

            return Ok(results);
        }

    }
}