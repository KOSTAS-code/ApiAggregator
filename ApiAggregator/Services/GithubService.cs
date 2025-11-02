using System.Threading.Tasks;

namespace ApiAggregator.Services
{
    public class GithubService
    {
        // This method simulates getting repository info from GitHub API
        public async Task<object> GetGithubAsync()
        {
            try
            {
                // Simulate async API call delay
                await Task.Delay(300);

                // Return a fake repository object
                return new
                {
                    source = "GitHub",
                    repo = "ApiAggregator-Example",
                    stars = 123
                };
            }
            catch
            {
                // Simple fallback if API call fails
                return new
                {
                    source = "GitHub",
                    error = "Could not retrieve GitHub data"
                };
            }
        }
    }
}
