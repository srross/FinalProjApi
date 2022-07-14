using FinalProjApi.Data;
using FinalProjApi.Models;
using FinalProjApi.Services.Interfaces;

namespace FinalProjApi.Services

{
    public class OutfitWeatherService : IOutfitWeatherService
    {
        private readonly FinalProjectDBContext _context;

        public OutfitWeatherService(FinalProjectDBContext context)
        {
            _context = context;
        }

        public async Task<List<OutfitWeather>> GetCurrentWeatherOutfit(double currentTemperature)
        {
            var defaultOutfit = _context.Outfits.Where(x => x.MinTemperature <= currentTemperature && x.MaxTemperature >= currentTemperature).ToList();

            return defaultOutfit;
        }
        
        // Cleanup later
        //public async Task<List<OutfitWeather>> GetAllOutfitsByUserId(int userId)
        //{
        //    var userOutfits = _context.Outfits.Where(x => x.UserId == userId).ToList();

        //    return userOutfits;
        //}
    }
}