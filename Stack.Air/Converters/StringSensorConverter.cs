using System;
using com.b_velop.Stack.Air.Data.Enums;
using Newtonsoft.Json;

namespace com.b_velop.Stack.Air.Converters
{
    public class StringSensorConverter : JsonConverter
    {
        public override bool CanConvert(
            Type objectType)
            => true;

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
            => reader.Value.ToString() switch
            {
                "SDS_P1" => SensorType.SdsP1,
                "SDS_P2" => SensorType.SdsP2,
                "humidity" => SensorType.DhtHumidity,
                "temperature" => SensorType.DhtTemperature,
                "BMP_pressure" => SensorType.BmpPressure,
                "BMP_temperature" => SensorType.BmpTemperature,
                "samples" => SensorType.Samples,
                "min_micro" => SensorType.MinMicro,
                "max_micro" => SensorType.MaxMicro,
                "signal" => SensorType.Signal,
                _ => SensorType.Unknown
            };

        public override void WriteJson(
            JsonWriter writer,
            object value,
            JsonSerializer serializer)
        {
        }
    }
}
