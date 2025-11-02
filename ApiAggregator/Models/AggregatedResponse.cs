namespace ApiAggregator.Models
{
    public class WeatherResponse
    {
        public string source { get; set; }
        public string city { get; set; }
        public int tempCelsius { get; set; }
        public string condition { get; set; }
    }

    public class NewsResponse
    {
        public string source { get; set; }
        public List<string> headlines { get; set; }
    }

    public class GithubResponse
    {
        public string source { get; set; }
        public string repo { get; set; }
        public int stars { get; set; }
    }
}