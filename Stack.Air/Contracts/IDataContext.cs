using System.Threading.Tasks;
using com.b_velop.Stack.Air.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace com.b_velop.Stack.Air.Contracts
{
    public interface IDataContext
    {
        DbSet<Value> Values { get; set; }
        DbSet<Time> Times { get; set; }
        DbSet<Sensor> Sensors { get; set; }
        Task<int> SaveChangesAsync();
        DbSet<T> Set<T>() where T : class;
    }
}
