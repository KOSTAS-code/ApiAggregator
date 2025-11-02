using ApiAggregator.Models;

namespace ApiAggregator.Services
{
    public class WeatherService
    {
        public async Task<WeatherResponse> GetWeatherAsync()
        {
            // Simulated API call
            await Task.Delay(50);

            return new WeatherResponse
            {
                source = "Weather",
                city = "Athens",
                tempCelsius = 22,
                condition = "Clear"
            };
        }
    }
}