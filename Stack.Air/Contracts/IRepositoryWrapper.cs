using System.Threading.Tasks;

namespace com.b_velop.Stack.Air.Contracts
{
    public interface IRepositoryWrapper
    {
        Task<int> SaveChangesAsync();

        public IValueRepository Values { get; }
        public ITimeRepository Times { get; }
        public ISensorRepository Sensors { get; }
    }
}
