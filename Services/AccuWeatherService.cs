using FinalProjApi.Data;
using FinalProjApi.Models;
using FinalProjApi.Services.Interfaces;

namespace FinalProjApi.Services
{
    public class AccuWeatherService : IAccuWeatherService
    {
        private readonly FinalProjectDBContext _context;

        public AccuWeatherService(FinalProjectDBContext context)
        {
            _context = context;
        }


           // var defaultOutfit = _context.Outfits.Where(x => x.MinTemperature <= currentTemperature && x.MaxTemperature >= currentTemperature).ToList();

        public async Task<List<CurrentWeather>> GetCurrentWeather(string zip)
        {

            List<LocationFinder>? response;

            List<CurrentWeather>? currentWeather;

            List<ZipCodeKey> zipCodeKeys = _context.ZipCodeKeys.ToList();

            string apiKey = "oQrLpa03Gz7mGh3Y9WXo0bJ7bFQWZNvl";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://dataservice.accuweather.com");

            // Put logic to check zip code and key here as method or code
            if (zip == null)
            {
                zip = "99705"; // North Pole Zip Code -- It should never be null as front end should check for null on form.
            }
            //int zipId = await _context.ZipCodeKeys.Where(a =>a.ZipCode == zip).FirstOrDefault().Id;
            var dbKeyObj = zipCodeKeys.FirstOrDefault(y => y.ZipCode == zip);
            if(dbKeyObj == null)
            // If zip not currently stored in database then go get key.
            {
                response = await client.GetFromJsonAsync<List<LocationFinder>>("/locations/v1/postalcodes/search?apikey=" + apiKey + "&q=" + zip);
                //var dbKey = response[0].Key;
                currentWeather = await client.GetFromJsonAsync<List<CurrentWeather>>("/currentconditions/v1/" + response[0].Key + "?apikey=" + apiKey + "&details=true");
                // Write zip and key to db
            }
            else
            {
                //var dbKey = dbZipCode.Key;
                currentWeather = await client.GetFromJsonAsync<List<CurrentWeather>>("/currentconditions/v1/" + dbKeyObj.Key + "?apikey=" + apiKey + "&details=true");
            }
             

            return currentWeather;
        }
    }
}
