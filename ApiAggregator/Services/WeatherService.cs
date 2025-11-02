using System.Threading.Tasks;

namespace ApiAggregator.Services
{
    public class WeatherService
    {
        // This method simulates fetching weather data from an external API
        public async Task<object> GetWeatherAsync()
        {
            try
            {
                // Simulate async API call delay
                await Task.Delay(300);

                // Return a sample JSON object
                return new
                {
                    source = "Weather",
                    city = "Athens",
                    tempCelsius = 22,
                    condition = "Clear"
                };
            }
            catch
            {
                // Simple fallback in case something goes wrong
                return new
                {
                    source = "Weather",
                    error = "Could not retrieve weather data"
                };
            }
        }
    }
}