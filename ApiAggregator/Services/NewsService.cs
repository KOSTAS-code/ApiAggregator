using System.Threading.Tasks;

namespace ApiAggregator.Services
{
    public class NewsService
    {
        // This method simulates getting top news from an external API
        public async Task<object> GetNewsAsync()
        {
            try
            {
                // Simulate async API call delay
                await Task.Delay(300);

                // Return some example headlines
                return new
                {
                    source = "News",
                    headlines = new string[]
                    {
                        "Story A",
                        "Story B"
                    }
                };
            }
            catch
            {
                // Fallback response in case of error
                return new
                {
                    source = "News",
                    error = "Could not retrieve news data"
                };
            }
        }
    }
}