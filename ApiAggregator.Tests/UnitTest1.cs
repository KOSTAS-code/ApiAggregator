using Xunit;
using ApiAggregator.Services;
using ApiAggregator.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiAggregator.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task WeatherService_Should_Return_Correct_Data()
        {
            // Arrange
            var service = new WeatherService();

            // Act
            var result = await service.GetWeatherAsync();

            // Assert
            Assert.Equal("Weather", result.source);
            Assert.Equal("Athens", result.city);
        }

        [Fact]
        public async Task NewsService_Should_Return_Headlines()
        {
            // Arrange
            var service = new NewsService();

            // Act
            var result = await service.GetNewsAsync();

            // Assert
            Assert.Equal("News", result.source);
            Assert.NotEmpty(result.headlines);
        }

        [Fact]
        public async Task Controller_Should_Aggregate_All_Sources()
        {
            // Arrange
            var weather = new WeatherService();
            var news = new NewsService();
            var github = new GithubService();

            var controller = new AggregateController(weather, news, github);

            // Act
            var actionResult = await controller.GetAggregate(true, true, true);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            dynamic data = okResult.Value!;

            Assert.NotNull(data.weather);
            Assert.NotNull(data.news);
            Assert.NotNull(data.github);
        }
    }
}