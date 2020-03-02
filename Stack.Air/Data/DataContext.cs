using System.Threading.Tasks;
using com.b_velop.Stack.Air.Contracts;
using com.b_velop.Stack.Air.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace com.b_velop.Stack.Air.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<Value> Values { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Sensor> Sensors { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public async Task<int> SaveChangesAsync() => await base.SaveChangesAsync();

        public DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
