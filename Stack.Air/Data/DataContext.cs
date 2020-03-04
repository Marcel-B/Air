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
        public DbSet<ValueType> ValueTypes { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
