using FinalProjApi.Models;

namespace FinalProjApi.Services.Interfaces
{
    public interface IOutfitWeatherService
    {
        Task<List<OutfitWeather>> GetCurrentWeatherOutfit(double currentTemperature);
        void AddOutfitToUserProfile(OutfitWeather outfit);
        void DeleteUserOutfit(int id);
        void UpdateUserOutfit(int id, OutfitWeather outfitWeather);

        //Task<List<OutfitWeather>> GetAllOutfitsByUserId(int userId);
    }
}