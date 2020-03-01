using com.b_velop.Stack.Air.Contracts;

namespace com.b_velop.Stack.Air.Data.Models
{
    public class Value : IEntity
    {
        public long Id { get; set; }
        public double MeasureValue { get; set; }
        public Time Timestamp { get; set; }
        public long TimestampId { get; set; }
        public Sensor Sensor { get; set; }
        public long SensorId { get; set; }
    }
}
