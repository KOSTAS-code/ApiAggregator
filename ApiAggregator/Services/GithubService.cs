using ApiAggregator.Models;

namespace ApiAggregator.Services
{
    public class GithubService
    {
        public async Task<GithubResponse> GetGithubAsync()
        {
            await Task.Delay(50);

            return new GithubResponse
            {
                source = "GitHub",
                repo = "ApiAggregator-Example",
                stars = 123
            };
        }
    }
}
