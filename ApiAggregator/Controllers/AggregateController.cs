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
        public async Task<IActionResult> Get(
            [FromQuery] bool includeWeather = true,
            [FromQuery] bool includeNews = true,
            [FromQuery] bool includeGithub = true)
        {
            // Ξεκινάμε tasks μόνο για όσα ζήτησε ο client
            Task<object>? weatherTask = includeWeather
                ? SafeCall(_weatherService.GetDataAsync, "Weather")
                : null;

            Task<object>? newsTask = includeNews
                ? SafeCall(_newsService.GetDataAsync, "News")
                : null;

            Task<object>? githubTask = includeGithub
                ? SafeCall(_githubService.GetDataAsync, "GitHub")
                : null;

            // Μαζεύουμε όσα δεν είναι null για να τα περιμένουμε όλα μαζί
            var taskList = new List<Task<object>>();
            if (weatherTask != null) taskList.Add(weatherTask);
            if (newsTask != null) taskList.Add(newsTask);
            if (githubTask != null) taskList.Add(githubTask);

            await Task.WhenAll(taskList);

            var response = new AggregatedResponse
            {
                Weather = weatherTask != null ? weatherTask.Result : null,
                News = newsTask != null ? newsTask.Result : null,
                Github = githubTask != null ? githubTask.Result : null
            };

            return Ok(response);
        }
        private static async Task<object> SafeCall(Func<Task<object>> action, string sourceName)
        {
            try
            {
                return await action();
            }
            catch (Exception ex)
            {
                // εδώ κάνουμε graceful fallback
                return new
                {
                    Source = sourceName,
                    Error = "unavailable",
                    Details = ex.Message
                };
            }
        }
    }
}