using Microsoft.AspNetCore.Mvc;
using ApiAggregator.Services;
using ApiAggregator.Models;

namespace ApiAggregator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AggregateController : ControllerBase
    {
        private readonly WeatherService _weatherService;
        private readonly NewsService _newsService;
        private readonly GithubService _githubService;

        // Constructor injection for services
        public AggregateController(
            WeatherService weatherService,
            NewsService newsService,
            GithubService githubService)
        {
            _weatherService = weatherService;
            _newsService = newsService;
            _githubService = githubService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAggregatedData(
            bool includeWeather = true,
            bool includeNews = true,
            bool includeGithub = true)
        {
            // Prepare tasks based on the selected sources
            var tasks = new List<Task<object?>>();

            if (includeWeather)
                tasks.Add(_weatherService.GetWeatherAsync());

            if (includeNews)
                tasks.Add(_newsService.GetNewsAsync());

            if (includeGithub)
                tasks.Add(_githubService.GetGithubAsync());

            // Run all selected API calls in parallel
            var results = await Task.WhenAll(tasks);

            // Create response
            var aggregated = new AggregatedResponse
            {
                Weather = includeWeather ? results.ElementAtOrDefault(0) : null,
                News = includeNews ? results.ElementAtOrDefault(1) : null,
                Github = includeGithub ? results.ElementAtOrDefault(2) : null
            };

            // Return JSON response to the client
            return Ok(aggregated);
        }
    }
}