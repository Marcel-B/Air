using System.IO;
using System.Linq;
using com.b_velop.Stack.Air.Data.Dtos;
using com.b_velop.Stack.Air.Data.Enums;
using Newtonsoft.Json;
using NUnit.Framework;
using Snapper;
using Snapper.Attributes;

namespace Stack.Air.Tests
{
    public class AirFromSensorDtoTests
    {
        string jsonString = string.Empty;

        [SetUp]
        public void Setup()
        {
            jsonString = File.ReadAllText("airExample.json");
        }

        [Test]
        public void ConverterDeserializesAllTypesToValidEnums()
        {
            // Arrange
            // Act
            var sut = JsonConvert.DeserializeObject<AirFromSensorDto>(jsonString);
            var actual = sut.SensorDataValues.Any(_ => _.Sensor == SensorType.Unknown);

            // Assert
            Assert.IsFalse(actual);
        }

        [Test]
        public void AirDtoDeserializeNameAsExpected()
        {
            var sut = JsonConvert.DeserializeObject<AirFromSensorDto>(jsonString);
            var actual = sut.Name;

            actual.ShouldMatchSnapshot();
        }

        [Test]
        public void AirDtoDeserializeSoftwareVersionAsExpected()
        {
            var sut = JsonConvert.DeserializeObject<AirFromSensorDto>(jsonString);
            var actual = sut.SoftwareVersion;

            actual.ShouldMatchSnapshot();
        }

        [Test]
        public void AirDtoDeserializeSensorDataValuesAsExpected()
        {
            var sut = JsonConvert.DeserializeObject<AirFromSensorDto>(jsonString);
            var actual = sut.SensorDataValues;

            Assert.That(actual.Count() == 10);
        }
    }
}