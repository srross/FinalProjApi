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
        public IActionResult UpdateUserOutfit(int outfitId, Outfit outfit)
        {
            if (outfit.AuthUserId == "defaultUserAuthUserId123456789")
            {
                return BadRequest();
            }

            var update= _outfitService.UpdateUserOutfit(GetUserAuthId(), outfitId, outfit);
            return NoContent();
        }

        // DELETE: api/OutfitA/5
        [HttpDelete("DeleteUserOutfit/{outfitId}")]
        public IActionResult DeleteUserOutfit(int outfitId)
        {
           var message= _outfitService.DeleteUserOutfit(GetUserAuthId(), outfitId);
            return NoContent();
        }

        [HttpGet("GetOutfitById")]
        public IActionResult GetOutfitById(int id)
        {
            return Ok(_outfitService.GetOutfitById(id));
        }
    }
}