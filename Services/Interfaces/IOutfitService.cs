using FinalProjApi.Models;

namespace FinalProjApi.Services.Interfaces
{
    public interface IOutfitService
    {
        List<Outfit> GetOutfitByTemperature(double currentTemperature);
        List<Outfit> GetAllOutfits();
        List<Outfit> GetAllOutfitsByAuthId(string authId);
        void AddOutfitToUserProfile(Outfit outfit);
        void DeleteUserOutfit(int id);
        void UpdateUserOutfit(int id, Outfit outfit);      
    }
}