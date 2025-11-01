# API Aggregator (.NET 8)

A Web API built with **ASP.NET Core 8** that aggregates data from multiple external sources (Weather, News, GitHub)
and returns a unified JSON response through a single endpoint.

---

## 🚀 Features

- **Parallel API Calls** – Executes multiple external API calls concurrently using `Task.WhenAll()`.
- **Error Handling & Fallback** – Ensures the API remains operational even if one source fails.
- **Filtering** – Query parameters allow inclusion/exclusion of specific data sources (Weather, News, GitHub).
- **Swagger Integration** – Auto-generated API documentation with interactive testing.
- **Unit Tests (xUnit)** – Verifies core functionality and filtering logic.

---

## 🧠 Project Structure

ApiAggregator/
├── Controllers/
│ └── AggregateController.cs
├── Services/
│ ├── IExternalApiService.cs
│ ├── WeatherService.cs
│ ├── NewsService.cs
│ └── GithubService.cs
├── Models/
│ └── AggregatedResponse.cs
├── Program.cs
├── appsettings.json
└── ApiAggregator.http

ApiAggregator.Tests/
├── Fakes/
│ ├── FakeWeatherService.cs
│ ├── FakeNewsService.cs
│ └── FakeGithubService.cs
└── UnitTest1.cs

---

## 🧩 Technologies Used

- **.NET 8 / ASP.NET Core Web API**
- **C#**
- **xUnit** (for unit testing)
- **Swagger**

---

## 🧪 How to Run

1. Clone the repository  
   ```bash
   git clone https://github.com/kostas-code/ApiAggregator.git
Open the solution in Visual Studio 2022, or run from CLI:

bash
Αντιγραφή κώδικα
cd ApiAggregator
dotnet run
Open your browser at:

bash
Αντιγραφή κώδικα
https://localhost:<port>/swagger
Use Swagger UI to test the endpoint:

bash
Αντιγραφή κώδικα
GET /api/aggregate

## ✅ Example Response

```json
{
  "weather": {
    "source": "Weather",
    "city": "Athens",
    "tempCelsius": 22,
    "condition": "Clear"
  },
  "news": {
    "source": "News",
    "headlines": [
      "Breaking story A",
      "Breaking story B"
    ]
  },
  "github": {
    "source": "GitHub",
    "repo": "example-repo",
    "stars": 123
  }
}

🧪 Tests

Run tests using Visual Studio’s Test Explorer:

dotnet test


Expected output:

Total tests: 2
Passed: 2
Failed: 0

---
  
## 👤 Author
**Kostas Vesdekis**  
Junior .NET Developer | Backend Enthusiast  
📧 konstantinosbesdekes@gmail.com  
🔗 [LinkedIn](https://www.linkedin.com/in/konstantinos-vesdekis-32b9082a7)