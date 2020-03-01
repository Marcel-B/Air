using System;
using com.b_velop.Stack.Air.Contracts;

namespace com.b_velop.Stack.Air.Data.Models
{
    public class Timeable : ITimeable
    {
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public long Id { get; set; }
    }
}
