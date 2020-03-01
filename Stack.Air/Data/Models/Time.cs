using System;
using System.Collections.Generic;

namespace com.b_velop.Stack.Air.Data.Models
{
    public class Time
    {
        public long Id { get; set; }
        public DateTime Timestamp { get; set; }
        public ICollection<Value> Values { get; set; }
    }
}
