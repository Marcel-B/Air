using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.b_velop.Stack.Air.Contracts;

namespace com.b_velop.Stack.Air.BL
{
    public class ArethmeticMean : IAlgorithm
    {
        public ArethmeticMean()
        {
        }

        public async Task<double> Calculate(
            IEnumerable<double> values)
        {
            var result = .0;
            foreach (var value in values)
            {
                result += value;
            }
            result /= values.Count();
            return await Task.FromResult(result);
        }
    }
}
