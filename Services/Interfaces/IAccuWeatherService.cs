using FinalProjApi.Models;

namespace FinalProjApi.Services.Interfaces
{
    public interface IAccuWeatherService
    {
        Task<List<CurrentWeather>> GetCurrentWeather(string zip);
    }
}
