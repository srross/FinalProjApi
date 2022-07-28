using FinalProjApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjApi.Services.Interfaces
{
    public interface IOutfitService
    {
        List<Outfit> GetOutfitByTemperature(string authUserId, double currentTemperature);
        List<Outfit> GetAllOutfits();
        List<Outfit> GetAllOutfitsByAuthUserId(string authId);
        string AddOutfitToUserProfile(string authUserId, Outfit outfit);
        string DeleteUserOutfit(string authUserId, int outfitId);
        Outfit GetOutfitById(int id);
        string UpdateUserOutfit(string authUserId, int outfitId, Outfit outfit);
    }
}