using com.b_velop.Stack.Air.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace com.b_velop.Stack.Air.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Value> Values { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Sensor> Sensors { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
