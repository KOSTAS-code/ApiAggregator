namespace ApiAggregator.Services
{
    public class NewsService : IExternalApiService
    {
        public virtual async Task<object> GetDataAsync()
        {
            await Task.Delay(10);
            return new
            {
                Source = "News",
                Headlines = new[]
                {
                    "Breaking story A",
                    "Breaking story B"
                }
            };
        }
    }
}
