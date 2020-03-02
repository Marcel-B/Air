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
        public static void SeedSensors(IDataContext context)
        {
            if (!context.Sensors.Any())
            {
                var sensorData = File.ReadAllText("Data/sensor.json");
                var sensors = JsonConvert.DeserializeObject<IEnumerable<Sensor>>(sensorData);
                foreach (var sensor in sensors)
                {
                    sensor.Created = DateTime.UtcNow;
                    context.Sensors.Add(sensor);
                }
                context.SaveChanges();
            }
        }
    }
}
