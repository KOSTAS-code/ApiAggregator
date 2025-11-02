using ApiAggregator.Models;

namespace ApiAggregator.Services
{
    public class NewsService
    {
        public async Task<NewsResponse> GetNewsAsync()
        {
            await Task.Delay(50);

            return new NewsResponse
            {
                source = "News",
                headlines = new List<string> { "Story A", "Story B" }
            };
        }
    }
}