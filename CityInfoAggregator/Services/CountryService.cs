using System.Text.Json;

public class CountryService
{
    private readonly HttpClient _client;

    public CountryService()
    {
        _client = new HttpClient
        {
            BaseAddress = new Uri("https://restcountries.com/v3.1/")
        };
    }

    public async Task<CountryResponse?> GetCountryAsync(string countryCode)
    {
        var response = await _client.GetAsync($"alpha/{countryCode}");

        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine($"Errore paese: {response.StatusCode}");
            return null;
        }

        var json = await response.Content.ReadAsStringAsync();

        var countries = JsonSerializer.Deserialize<CountryResponse[]>(
            json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return countries?[0];
    }
}
