public class CityInfoService
{
    private readonly WeatherService _weatherService;
    private readonly CountryService _countryService;

    public CityInfoService(WeatherService weatherService, CountryService countryService)
    {
        _weatherService = weatherService;
        _countryService = countryService;
    }

    public async Task<CityInfo?> GetCityInfoAsync(string city)
    {
        var weather = await _weatherService.GetWeatherAsync(city);
        if (weather == null) return null;

        var country = await _countryService.GetCountryAsync(weather.Sys.Country);
        if (country == null) return null;

        return new CityInfo
        {
            City = weather.Name,
            Country = country.Name.Common,
            Temperature = weather.Main.Temp,
            Weather = weather.Weather[0].Description,
            Population = country.Population,
            FlagUrl = country.Flags.Png
        };
    }
}
