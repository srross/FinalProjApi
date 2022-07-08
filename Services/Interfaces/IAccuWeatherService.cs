using FinalProjApi.Models;

namespace FinalProjApi.Services.Interfaces
{
    public interface IAccuWeatherService
    {
        //Task<List<LocationFinder>> GetLocationKey(string zip);
        Task<List<CurrentWeather>> GetCurrentWeather(string zip);
    }
}
