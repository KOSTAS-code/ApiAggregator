namespace ApiAggregator.Services
{
    public interface IExternalApiService
    {
        Task<object> GetDataAsync();
    }
}
