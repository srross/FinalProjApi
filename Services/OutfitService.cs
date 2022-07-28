using FinalProjApi.Controllers;
using FinalProjApi.Data;
using FinalProjApi.Models;
using FinalProjApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FinalProjApi.Services

{
    public class OutfitService : IOutfitService
    {
        private readonly FinalProjectDBContext _context;

        public OutfitService(FinalProjectDBContext context)
        {
            _context = context;
        }

        public List<Outfit> GetOutfitByTemperature(string authUserId, double currentTemperature)
        {
            var outfit = new List<Outfit>();

            outfit = _context.Outfits.Where(x => x.MinTemperature <= currentTemperature
                                               && x.MaxTemperature >= currentTemperature
                                               && x.AuthUserId == authUserId).ToList();
            if(outfit.Count == 0)
            {
                var defaultOutfit = _context.Outfits.Where(x => x.MinTemperature <= currentTemperature
                                               && x.MaxTemperature >= currentTemperature
                                               && x.AuthUserId == "defaultUserAuthUserId123456789").ToList();
                return defaultOutfit;
            }
            return outfit;
        }

        public List<Outfit> GetAllOutfits()
        {
            return _context.Outfits.ToList();
        }

        public List<Outfit> GetAllOutfitsByAuthUserId(string authId)
        {
            return _context.Outfits.Where(x => x.AuthUserId == authId).ToList();
        }

        public string AddOutfitToUserProfile(string authUserId, Outfit outfit)
        {
            // check for existing outfit in temperature range. if exists, return that outfit for update
            var existingOutfit = _context.Outfits.Where(o => o.MinTemperature == outfit.MinTemperature
                                                          && o.MaxTemperature == outfit.MaxTemperature
                                                          && o.AuthUserId == authUserId);

            if (existingOutfit.Any())
            {
                return $"Outfit already exist for temperature range {outfit.MinTemperature} - {outfit.MaxTemperature}.";
            }
            outfit.AuthUserId = authUserId;
            _context.Entry(outfit).State = EntityState.Added;

            try
            {
                _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return "success";
        }

        public string UpdateUserOutfit(string authUserId, int outfitId, Outfit outfit)
        {
            _context.Entry(outfit).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return "success message";
        }

        public string DeleteUserOutfit(string authUserId, int outfitId)
        {
            var outfit = _context.Outfits.Find(outfitId);

            if (outfit == null)
            {
                return "Outfit not found";
            }

            if (outfit.AuthUserId == "defaultUserAuthUserId123456789")
            {
                return "Deletion of default outfit not allowed.";
            }

            _context.Entry(outfit).State = EntityState.Deleted;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
            return "success message";
        }
    }
}