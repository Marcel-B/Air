using System.Collections.Generic;

namespace com.b_velop.Stack.Air.Data.Models
{
    public class ValueType : Timeable
    {
        public string Name { get; set; }
        public string Display { get; set; }
        ICollection<Sensor> Sensors { get; set; }
    }
}
