using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace com.b_velop.Stack.Air.Data.Dtos
{

    public class AirFromSensorDto
    {
        public AirFromSensorDto()
        {
            Time = DateTimeOffset.Now;
        }

        [JsonIgnore]
        public DateTimeOffset Time { get; set; }

        [JsonProperty("esp8266id")]
        public string Name { get; set; }

        [JsonProperty("software_version")]
        public string SoftwareVersion { get; set; }

        [JsonProperty("sensordatavalues")]
        public IEnumerable<SensorDataValueDto> SensorDataValues { get; set; }
    }
}
