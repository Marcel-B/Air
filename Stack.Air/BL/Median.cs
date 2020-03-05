using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.b_velop.Stack.Air.Contracts;

namespace com.b_velop.Stack.Air.BL
{
    public class Median : IAlgorithm
    {
        public Median()
        {
        }

        public async Task<double> Calculate(
            IEnumerable<double> values)
        {
            var list = values.ToList();
            list.Sort();
            var middleIdx = list.Count / 2;
            var element = list[middleIdx];
            if(list.Count % 2 == 0)
            {
                element +=  list[--middleIdx];
                element /= 2;
            }
            return  await Task.FromResult(element);
        }
    }
}
