using FinalProjApi.Models;

namespace FinalProjApi.Services.Interfaces
{
    public interface IAccuWeatherService
    {
        Task<List<LocationFinder>> GetLocationKey(string zip);
    }
}
