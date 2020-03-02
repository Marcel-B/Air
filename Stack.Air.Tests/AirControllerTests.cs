using System;
using System.Threading.Tasks;
using AutoMapper;
using com.b_velop.Stack.Air.Data;
using com.b_velop.Stack.Air.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Stack.Air.Controllers;

namespace Stack.Air.Tests
{
    public class AirControllerTests
    {
        [SetUp]
        public void Setup()
        {

        }

        public Mock<IMapper> GetMapperMock()
        {
            var mock = new Mock<IMapper>();
            return mock;
        }

        public Mock<DataContext> GetDataContextMock()
        {
            var mock = new Mock<DataContext>();
            return mock;
        }

        public AirFromSensorDto GetAirFromSensorDto()
        {
            var mock = new AirFromSensorDto
            {
                Name = "0815"
            };
            return mock;
        }

        [Test]
        public async Task ReturnUnauthorizedWhenSensorIdIsNotCorrect()
        {
            // Arrange
            var sut = new AirsController(null, GetMapperMock().Object);

            // Act
            var actual = await sut.PostAirAsync(GetAirFromSensorDto());

            // Assert
            Assert.IsInstanceOf<UnauthorizedResult>(actual);
        }
    }
}
