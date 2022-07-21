using FinalProjApi.Data;
using FinalProjApi.Models;
using FinalProjApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProjApi.Services

{
    public class OutfitService : IOutfitService
    {
        private readonly FinalProjectDBContext _context;

        public OutfitService(FinalProjectDBContext context)
        {
            _context = context;
        }

        public List<Outfit> GetOutfitByTemperature(double currentTemperature)
        {
            return _context.Outfits.Where(x => x.MinTemperature <= currentTemperature && x.MaxTemperature >= currentTemperature).ToList();
        }

        public List<Outfit> GetAllOutfits()
        {
            return _context.Outfits.ToList();
        }

        public List<Outfit> GetAllOutfitsByAuthId(string authId)
        {
            return _context.Outfits.Where(x => x.AuthUserId == authId).ToList();
        }

        public async void AddOutfitToUserProfile(Outfit outfit)
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

        public void UpdateUserOutfit(int id, Outfit outfit)
        {
            if (id != outfit.Id)
            {
                //return "BadRequest";
            }

            _context.Entry(outfit).State = EntityState.Modified;

            try
            {
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OutfitExists(id))
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

        private bool OutfitExists(int id)
        {
            return (_context.Outfits?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}