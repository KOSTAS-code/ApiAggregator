using System.Threading.Tasks;
using ApiAggregator.Controllers;
using ApiAggregator.Models;
using ApiAggregator.Tests.Fakes;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ApiAggregator.Tests
{
    public class AggregateControllerTests
    {
        [Fact]
        public async Task Get_ReturnsAggregatedResponse_WithAllSources()
        {
            // Arrange
            var controller = new AggregateController(
                new FakeWeatherService(),
                new FakeNewsService(),
                new FakeGithubService()
            );

            // Act
            var result = await controller.Get(
                includeWeather: true,
                includeNews: true,
                includeGithub: true
            );

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<AggregatedResponse>(okResult.Value);

            Assert.NotNull(response.Weather);
            Assert.NotNull(response.News);
            Assert.NotNull(response.Github);
        }

        [Fact]
        public async Task Get_CanExclude_Github_Service()
        {
            var controller = new AggregateController(
                new FakeWeatherService(),
                new FakeNewsService(),
                new FakeGithubService()
            );

            var result = await controller.Get(
                includeWeather: true,
                includeNews: true,
                includeGithub: false
            );

            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<AggregatedResponse>(okResult.Value);

            Assert.NotNull(response.Weather);
            Assert.NotNull(response.News);
            Assert.Null(response.Github);
        }
    }
}