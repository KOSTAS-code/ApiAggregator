using ApiAggregator.Models;
using ApiAggregator.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiAggregator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AggregateController : ControllerBase
    {
        private readonly WeatherService _weatherService;
        private readonly NewsService _newsService;
        private readonly GithubService _githubService;

        // Constructor services
        public AggregateController(
            WeatherService weatherService,
            NewsService newsService,
            GithubService githubService)
        {
            _weatherService = weatherService;
            _newsService = newsService;
            _githubService = githubService;
        }

        // Main endpoint to aggregate data from multiple sources
        [HttpGet]
        public async Task<IActionResult> GetAggregate(
            bool includeWeather = true,
            bool includeNews = true,
            bool includeGithub = true)
        {
            // Create a list to store async tasks
            var tasks = new List<Task>();

            // Initialize response objects
            WeatherResponse weather = null;
            NewsResponse news = null;
            GithubResponse github = null;

            // Call each service depending on input parameters
            if (includeWeather)
                tasks.Add(Task.Run(async () => weather = await _weatherService.GetWeatherAsync()));

            if (includeNews)
                tasks.Add(Task.Run(async () => news = await _newsService.GetNewsAsync()));

            if (includeGithub)
                tasks.Add(Task.Run(async () => github = await _githubService.GetGithubAsync()));

            // Wait for all async calls to complete in parallel
            await Task.WhenAll(tasks);

            // Combine results into a single object
            var result = new
            {
                weather,
                news,
                github
            };

            // Return JSON response
            return Ok(result);
        }
    }
}