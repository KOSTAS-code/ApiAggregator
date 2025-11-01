
using ApiAggregator.Services;

namespace ApiAggregator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // Add services to the controllers.
            builder.Services.AddControllers();

            // Swagger services
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register services
          // builder.Services.AddScoped<IExternalApiService, WeatherService>();
            builder.Services.AddScoped<WeatherService>();
            builder.Services.AddScoped<NewsService>();
            builder.Services.AddScoped<GithubService>();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapControllers();
            app.Run();
        }
    }
}
