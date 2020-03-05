using System.Threading.Tasks;
using com.b_velop.Stack.Air.BL;
using NUnit.Framework;

namespace Stack.Air.Tests
{
    public class AlgorithmTests
    {
        [TestCase(new[] { 3.3, 1.1, 5.5 }, 3.3)]
        [TestCase(new[] { 0.2, 1.1, 5.5 }, 1.1)]
        [TestCase(new[] { 1.1, 5.5, 2.2 }, 2.2)]
        [TestCase(new[] { 2.0, 1.0, 6.0, 8.0 }, 4.0)]
        public async Task Median_Calculate_ReturnsMedian(
            double[] values,
            double expected)
        {
            // Arrange
            var sut = new Median();

            // Act
            var actual = await sut.Calculate(values);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 2d, 4d, 6d }, 4d)]
        [TestCase(new[] { 2d, 4d, 6d, 200d }, 53d)]
        public async Task Median_Calculate_ReturnsArethmeticMean(
            double[] values,
            double expected)
        {
            // Arrange
            var sut = new ArethmeticMean();

            // Act
            var actual = await sut.Calculate(values);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
