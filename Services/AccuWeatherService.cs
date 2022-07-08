using FinalProjApi.Models;
using FinalProjApi.Services.Interfaces;

namespace FinalProjApi.Services
{
    public class AccuWeatherService : IAccuWeatherService
    {
        public async Task<List<CurrentWeather>> GetCurrentWeather(string zip)
        {
            // Put logic to check zip code and key here as method or code


            string apiKey = "oQrLpa03Gz7mGh3Y9WXo0bJ7bFQWZNvl";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://dataservice.accuweather.com");
            var response = await client.GetFromJsonAsync<List<LocationFinder>>("/locations/v1/postalcodes/search?apikey=" + apiKey + "&q=" + zip);
            var currentWeather = await client.GetFromJsonAsync<List<CurrentWeather>>("/currentconditions/v1/" + response[0].Key + "?apikey=" + apiKey + "&details=true");

            return currentWeather;
        }
    }
}
