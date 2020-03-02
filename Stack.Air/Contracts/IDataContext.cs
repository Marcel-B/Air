using System.Threading;
using System.Threading.Tasks;
using com.b_velop.Stack.Air.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace com.b_velop.Stack.Air.Contracts
{
    public interface IDataContext
    {
        DbSet<Value> Values { get; set; }
        DbSet<Time> Times { get; set; }
        DbSet<Sensor> Sensors { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        int SaveChanges();
        DbSet<T> Set<T>() where T : class;
        DatabaseFacade Database { get; }
    }
}
