class Program
{
    static async Task Main()
    {
        var weatherService = new WeatherService("6bb7d7fb8cfdf02533cfafb723985432");

        var countryService = new CountryService();
        var cityInfoService = new CityInfoService(weatherService, countryService);

        Console.Write("Inserisci una città: ");
        string city = Console.ReadLine();

        var info = await cityInfoService.GetCityInfoAsync(city);

        if (info == null)
        {
            Console.WriteLine("Errore nel recupero dati");
            return;
        }

        Console.WriteLine("\n--- CITY INFO ---");
        Console.WriteLine($"City: {info.City}");
        Console.WriteLine($"Country: {info.Country}");
        Console.WriteLine($"Temperature: {info.Temperature} °C");
        Console.WriteLine($"Weather: {info.Weather}");
        Console.WriteLine($"Population: {info.Population:N0}");
        Console.WriteLine($"Flag: {info.FlagUrl}");
    }
}
