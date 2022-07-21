using FinalProjApi.Data;
using FinalProjApi.Models;
using FinalProjApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutfitController : BaseController
    {
        private readonly IOutfitService _outfitService;

        public OutfitController(IOutfitService outfitService, FinalProjectDBContext context)
        {
            _outfitService = outfitService;
        }

        // GET: Outfit/GetOutfitByTemperature/52
        [HttpGet("GetOutfitByTemperature/{temperature}")]
        public List<Outfit> GetOutfitByTemperature(double temperature)
        {
            return _outfitService.GetOutfitByTemperature(temperature);
        }

        // GET: 'Outfit/GetAllOutfits'
        [HttpGet("GetAllOutfits")]
        public List<Outfit> GetAllOutfits()
        {
            return _outfitService.GetAllOutfits();
        }

        // GET: 'Outfit/GetAllOutfitsByUserId/1
        [HttpGet("GetAllOutfitsByAuthId")]
        public List<Outfit> GetAllOutfitsByAuthId()
        {
            return _outfitService.GetAllOutfitsByAuthId(GetUserAuthId());
        }

        // POST: Outfit/AddOutfitToUserProfile, outfitObj
        [HttpPost("AddOutfitToUserProfile")]
        public List<Outfit> AddOutfitToUserProfile(Outfit outfitObj)
        {
            var userId = outfitObj.Id;

            _outfitService.AddOutfitToUserProfile(outfitObj);

            return _outfitService.GetAllOutfitsByAuthId(GetUserAuthId());
        }

        // PUT: api/Outfit/5
        [HttpPut("UpdateUserOutfit/{outfitId}")]
        public void UpdateUserOutfit(int outfitId, Outfit outfitObj)
        {
            // maybe add userId 999 as a condition check on default outfit.
            // add check for doesOutfitExist()
            if (outfitId > 8)
            {
                _outfitService.UpdateUserOutfit(outfitId, outfitObj);
                //return NoContent();
            }
        }

        // DELETE: api/OutfitA/5
        // Consider soft delete for user outfit history ( add isActive or archive column to table)
        [HttpDelete("DeleteUserOutfit/{outfitId}")]
        public void DeleteUserOutfit(int outfitId)
        {
            // maybe add userId 999 as a condition check on default outfit.
            // add check for doesOutfitExist()
            if (outfitId > 8)
            {
                _outfitService.DeleteUserOutfit(outfitId);
                //return NoContent();
            }
        }
    }
}