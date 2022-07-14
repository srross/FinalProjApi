using FinalProjApi.Models;

namespace FinalProjApi.Services.Interfaces
{
    public interface IOutfitWeatherService
    {
        Task<List<OutfitWeather>> GetCurrentWeatherOutfit(double currentTemperature);
        //Task<List<OutfitWeather>> GetAllOutfitsByUserId(int userId);
    }
}