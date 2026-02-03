using System.Text.Json;

public class WeatherService
{
    private readonly HttpClient _client;
    private readonly string _apiKey;

    public WeatherService(string apiKey)
    {
        _apiKey = apiKey;
        _client = new HttpClient
        {
            BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/")
        };
    }

    public async Task<WeatherResponse?> GetWeatherAsync(string city)
    {
        var response = await _client.GetAsync(
            $"weather?q={city}&units=metric&lang=it&appid={_apiKey}");

        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine($"Errore meteo: {response.StatusCode}");
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            return null;
        }

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<WeatherResponse>(
            json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
}
