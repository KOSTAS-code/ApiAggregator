using ApiAggregator.Services;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Register our custom services
// These are simple classes, so Singleton works fine for now
builder.Services.AddSingleton<WeatherService>();
builder.Services.AddSingleton<NewsService>();
builder.Services.AddSingleton<GithubService>();

// Add Swagger for testing and documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger only in Development mode
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Basic middleware setup
app.UseHttpsRedirection();

app.MapControllers();

app.Run();