# API Aggregator (.NET 8)

A Web API built with ASP.NET Core 8 that aggregates data from multiple external sources (Weather, News, GitHub)
and returns a unified JSON response through a single endpoint.

---

## Features

- Parallel API Calls – Executes multiple external API calls concurrently using Task.WhenAll().
- Error Handling & Fallback – Ensures the API remains operational even if one source fails.
- Filtering – Query parameters allow inclusion/exclusion of specific data sources (Weather, News, GitHub).
- Swagger Integration – Auto-generated API documentation with interactive testing.
- Unit Tests (xUnit) – Verifies core functionality and filtering logic.

---

## Project Structure