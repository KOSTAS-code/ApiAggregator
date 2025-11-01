namespace ApiAggregator.Services
{
    public class GithubService : IExternalApiService
    {
        public virtual async Task<object> GetDataAsync()
        {
            await Task.Delay(10);
            return new
            {
                Source = "GitHub",
                Repo = "example-repo",
                Stars = 123
            };
        }
    }
}
