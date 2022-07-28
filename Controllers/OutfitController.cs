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
            return _outfitService.GetOutfitByTemperature(GetUserAuthId(), temperature);
        }

        // GET: 'Outfit/GetAllOutfits'
        [HttpGet("GetAllOutfits")]
        public List<Outfit> GetAllOutfits()
        {
            return _outfitService.GetAllOutfits();
        }

        // GET: 'Outfit/GetAllOutfitsByAuthUserId/1
        [HttpGet("GetAllOutfitsByAuthId")]
        public List<Outfit> GetAllOutfitsByAuthUserId()
        {
            return _outfitService.GetAllOutfitsByAuthUserId(GetUserAuthId());

        }

        // POST: Outfit/AddOutfitToUserProfile, outfitObj
        [HttpPost("AddOutfitToUserProfile")]
        public void AddOutfitToUserProfile(Outfit outfit)
        {
            _outfitService.AddOutfitToUserProfile(GetUserAuthId(), outfit);
        }

        // PUT: api/Outfit/5
        [HttpPut("UpdateUserOutfit/{outfitId}")]
        public string UpdateUserOutfit(string authUserId, int outfitId, Outfit outfit)
        {
            if (outfit.AuthUserId == "defaultUserAuthUserId123456789")
            {
                return "Update to default outfit not allowed.";
            }

            if (authUserId != outfit.AuthUserId || outfitId != outfit.Id)
            {
                return "Id mismatch";
            }

            return _outfitService.UpdateUserOutfit(GetUserAuthId(), outfitId, outfit);
        }

        // DELETE: api/OutfitA/5
        [HttpDelete("DeleteUserOutfit/{outfitId}")]
        public IActionResult DeleteUserOutfit(int outfitId)
        {
           var message= _outfitService.DeleteUserOutfit(GetUserAuthId(), outfitId);
            return NoContent();
        }
    }
}