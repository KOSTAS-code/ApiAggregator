namespace ApiAggregator.Services
{
    public class WeatherService : IExternalApiService
    {
        public virtual async Task<object> GetDataAsync()
        {
            // TODO: Implement API call
            await Task.Delay(10);
            return new 
            {   
                Source = "Weather",
                City = "Athens",
                TempCelsius = 22,
                Condition = "Clear"
            };
        }
    }
}
