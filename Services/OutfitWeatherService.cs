using FinalProjApi.Data;
using FinalProjApi.Models;
using FinalProjApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async void AddOutfitToUserProfile(OutfitWeather outfit)
        {
            if (_context.Outfits == null)
            {
                //return Problem("Entity set 'FinalProjectDBContext.Outfits'  is null.");
            }
            _context.Outfits.Add(outfit);

            _context.SaveChangesAsync();
        }

        public void DeleteUserOutfit(int id)
        {
            var outfit = _context.Outfits.Find(id);

            if (outfit == null)
            {
                //return NotFound();
            }

            _context.Outfits.Remove(outfit);

            _context.SaveChangesAsync();
        }

        public void UpdateUserOutfit(int id, OutfitWeather outfitWeather)
        {
            if (id != outfitWeather.Id)
            {
                //return "BadRequest";
            }

            _context.Entry(outfitWeather).State = EntityState.Modified;

            try
            {
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OutfitWeatherExists(id))
                {
                    //return "NotFound";
                }
                else
                {
                    throw;
                }
            }

            //return "Looks like it worked.";
        }

        private bool OutfitWeatherExists(int id)
        {
            return (_context.Outfits?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        //public async Task<List<OutfitWeather>> GetAllOutfitsByUserId(int userId)
        //{
        //    var userOutfits = _context.Outfits.Where(x => x.UserId == userId).ToList();

        //    return userOutfits;
        //}
    }
}