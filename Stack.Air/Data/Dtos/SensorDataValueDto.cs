using com.b_velop.Stack.Air.Converters;
using com.b_velop.Stack.Air.Data.Enums;
using Newtonsoft.Json;

namespace com.b_velop.Stack.Air.Data.Dtos
{
    public class SensorDataValueDto
    {
        [JsonProperty("value_type")]
        [JsonConverter(typeof(StringSensorConverter))]
        public SensorType Sensor { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }
    }
}
