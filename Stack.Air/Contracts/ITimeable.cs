using System;
namespace com.b_velop.Stack.Air.Contracts
{
    public interface ITimeable : IEntity
    {
        DateTime Created { get; set; }
        DateTime? Updated { get; set; }
    }
}
