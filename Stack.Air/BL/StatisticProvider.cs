using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.b_velop.Stack.Air.Contracts;
using com.b_velop.Stack.Air.Data.Models;
using Microsoft.Extensions.DependencyInjection;

namespace com.b_velop.Stack.Air.BL
{
    public class StatisticProvider : IStatisticProvider
    {
        private IServiceProvider _serviceProvider;
        private IAlgorithm algorithm;

        public StatisticProvider(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<Statistic> GetStatistic(IEnumerable<double> values)
        {
            algorithm = _serviceProvider.GetRequiredService<Median>();
            var median = await algorithm.Calculate(values);

            algorithm = _serviceProvider.GetRequiredService<ArethmeticMean>();
            var am = await algorithm.Calculate(values);

            var result = new Statistic
            {
                Median = median,
                ArethmeticMean = am,
            };

            return result;
        }
    }
}
