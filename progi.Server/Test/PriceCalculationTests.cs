using progi.Server.Models;
using Xunit;

namespace progi.Server.Test
{
    public class PriceCalculationTests
    {
        [Fact]
        public void CalculatePrice_ShouldReturnCorrectTotalForLuxuryCar()
        {
            // Arrange
            var request = new PriceCalculationRequest
            {
                BasePrice = 1800,
                VehicleType = "Luxury"
            };

            // Act
            var result = new LuxuryCar(request.BasePrice).CalculatePrice(request);

            // Assert
            Assert.Equal(180.00m, result.Basic);
            Assert.Equal(72.00m, result.Special);
            Assert.Equal(15.00m, result.Association);
            Assert.Equal(100.00m, result.Storage);
            Assert.Equal(2167.00m, result.Total);
        }

        [Fact]
        public void CalculatePrice_ShouldReturnCorrectTotalForCommonCar()
        {
            // Arrange
            var request = new PriceCalculationRequest
            {
                BasePrice = 1100,
                VehicleType = "Common"
            };

            // Act
            var result = new CommonCar(request.BasePrice).CalculatePrice(request);

            // Assert
            Assert.Equal(50.00m, result.Basic);
            Assert.Equal(22.00m, result.Special);
            Assert.Equal(15.00m, result.Association);
            Assert.Equal(100.00m, result.Storage);
            Assert.Equal(1287.00m, result.Total);
        }

        [Fact]
        public void CalculatePrice_ShouldReturnCorrectTotalForLuxuryCar_DecimalTotals()
        {
            // Arrange
            var request = new PriceCalculationRequest
            {
                BasePrice = 2345,
                VehicleType = "Luxury"
            };

            // Act
            var result = new LuxuryCar(request.BasePrice).CalculatePrice(request);

            // Assert
            Assert.Equal(200.00m, result.Basic);
            Assert.Equal(93.80m, result.Special);
            Assert.Equal(15.00m, result.Association);
            Assert.Equal(100.00m, result.Storage);
            Assert.Equal(2753.80m, result.Total);
        }

        [Fact]
        public void CalculatePrice_ShouldReturnCorrectTotalForCommonCar_DecimalTotals()
        {
            // Arrange
            var request = new PriceCalculationRequest
            {
                BasePrice = 398,
                VehicleType = "Common"
            };

            // Act
            var result = new CommonCar(request.BasePrice).CalculatePrice(request);

            // Assert
            Assert.Equal(39.80m, result.Basic);
            Assert.Equal(7.96m, result.Special);
            Assert.Equal(5.00m, result.Association);
            Assert.Equal(100.00m, result.Storage);
            Assert.Equal(550.76m, result.Total);
        }

        [Fact]
        public void CalculatePrice_ShouldReturnCorrectTotalForLuxuryCar_HighPrice()
        {
            // Arrange
            var request = new PriceCalculationRequest
            {
                BasePrice = 1000000,
                VehicleType = "Luxury"
            };

            // Act
            var result = new LuxuryCar(request.BasePrice).CalculatePrice(request);

            // Assert
            Assert.Equal(200.00m, result.Basic);
            Assert.Equal(40000.00m, result.Special);
            Assert.Equal(20.00m, result.Association);
            Assert.Equal(100.00m, result.Storage);
            Assert.Equal(1040320.00m, result.Total);
        }

        [Fact]
        public void CalculatePrice_ShouldReturnCorrectTotalForCommonCar_HighPrice()
        {
            // Arrange
            var request = new PriceCalculationRequest
            {
                BasePrice = 1000000,
                VehicleType = "Common"
            };

            // Act
            var result = new CommonCar(request.BasePrice).CalculatePrice(request);

            // Assert
            Assert.Equal(50.00m, result.Basic);
            Assert.Equal(20000m, result.Special);
            Assert.Equal(20.00m, result.Association);
            Assert.Equal(100.00m, result.Storage);
            Assert.Equal(1020170.00m, result.Total);
        }
    }
}