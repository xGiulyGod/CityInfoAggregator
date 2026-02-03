# 🌍 City Info Aggregator (C#)

A simple **C# console application** that retrieves and aggregates information about a city using **public REST APIs**.

This project was created to practice:
- consuming real-world APIs
- working with HTTP requests in C#
- JSON deserialization
- clean project structure
- basic Git/GitHub workflow

---

## 🚀 Features

- Fetches current weather data for a city using **OpenWeather API**
- Uses `HttpClient` for HTTP requests
- Deserializes JSON responses into C# models
- Clean separation of concerns (Models / Services / Aggregator)

---

## 🛠️ Technologies Used

- **C#**
- **.NET**
- **HttpClient**
- **System.Text.Json**
- **OpenWeather API**
- **Git & GitHub**

---

## 📁 Project Structure

- CityInfoAggregator
- ├── Aggregator
- │ └── CityInfoAggregator.cs
- ├── Models
- │ └── WeatherResponse.cs
- ├── Services
- │ └── WeatherService.cs
- ├── Program.cs
- ├── README.md
- └── .gitignore


---

## 🔑 API Configuration

This project uses the **OpenWeather API**.

⚠️ For security reasons, the API key is **not hardcoded** in the source code.

You must set your API key as an **environment variable**.

### Windows (PowerShell)

```powershell
setx OPENWEATHER_API_KEY "your_api_key_here"