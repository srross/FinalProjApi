using FinalProjApi.Models;

namespace FinalProjApi.Services.Interfaces
{
    public interface IOutfitWeatherService
    {
        List<OutfitWeather> GetCurrentWeatherOutfit(int currentTemperature);
    }
}