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

        public List<OutfitWeather> GetCurrentWeatherOutfit(int currentTemperature)
        {
            var defaultOutfit = _context.Outfits.Where(x => x.MinTemperature <= currentTemperature && x.MaxTemperature >= currentTemperature).ToList();

            return defaultOutfit;

        }
    }
}
