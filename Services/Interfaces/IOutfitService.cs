using FinalProjApi.Models;

namespace FinalProjApi.Services.Interfaces
{
    public interface IOutfitService
    {
        Task<List<Outfit>> GetCurrentWeatherOutfit(double currentTemperature);
        void AddOutfitToUserProfile(Outfit outfit);
        void DeleteUserOutfit(int id);
        void UpdateUserOutfit(int id, Outfit outfit);

        //Task<List<Outfit>> GetAllOutfitsByUserId(int userId);
    }
}