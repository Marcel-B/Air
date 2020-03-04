using System.Collections.Generic;

namespace com.b_velop.Stack.Air.Data.Models
{
    public class Sensor : Timeable
    {
        public string Name { get; set; }
        public ValueType ValueType { get; set; }
        public long? ValueTypeId { get; set; }
        public ICollection<Value>  Values { get; set; }
    }
}
