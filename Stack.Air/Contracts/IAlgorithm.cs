using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.b_velop.Stack.Air.Contracts
{
    public interface IAlgorithm
    {
        Task<double> Calculate(IEnumerable<double> values);
    }
}
