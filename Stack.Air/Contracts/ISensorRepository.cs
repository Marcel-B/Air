using System.Collections.Generic;
using System.Threading.Tasks;
using com.b_velop.Stack.Air.Data.Models;

namespace com.b_velop.Stack.Air.Contracts
{
    public interface ISensorRepository : IRepositoryBase<Sensor>
    {
        Task<IEnumerable<Sensor>> GetAllIncludeAsync();
    }
}
