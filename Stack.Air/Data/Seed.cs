using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using com.b_velop.Stack.Air.Contracts;
using com.b_velop.Stack.Air.Data.Models;
using Newtonsoft.Json;

namespace com.b_velop.Stack.Air.Data
{
    public class Seed
    {
        public class ValueTypeSeedData
        {
            public string Name { get; set; }
            public string Display { get; set; }
        }

        public class SensorSeedData
        {
            public string Name { get; set; }
            public string ValueType { get; set; }
        }

        public static void SeedSensors(IDataContext context)
        {
            var json = File.ReadAllText("Data/valueTypes.json");
            var valueTypes = JsonConvert.DeserializeObject<IEnumerable<ValueTypeSeedData>>(json);
            var vTypes = context.ValueTypes;
            foreach (var valueType in valueTypes)
            {
                if (vTypes.FirstOrDefault(_ => _.Name == valueType.Name) == null)
                    context.ValueTypes.Add(new Models.ValueType
                    {
                        Name = valueType.Name,
                        Display = valueType.Display,
                        Created = DateTime.UtcNow
                    });
            }

            json = File.ReadAllText("Data/sensor.json");
            var sensors = JsonConvert.DeserializeObject<IEnumerable<SensorSeedData>>(json);
            var sTypes = context.Sensors;
            foreach (var sensor in sensors)
            {
                var s = sTypes.FirstOrDefault(_ => _.Name == sensor.Name);
                if (s == null)
                {
                    s = new Sensor
                    {
                        Name = sensor.Name,
                        Created = DateTime.UtcNow
                    };
                    context.Sensors.Add(s);
                }
                if (s.ValueTypeId == null)
                {
                    var t = vTypes.FirstOrDefault(_ => _.Name == sensor.ValueType);
                    s.ValueTypeId = t?.Id;
                }
            }
            context.SaveChanges();
        }
    }
}
