using FinalProjApi.Models;
using FinalProjApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutfitController : ControllerBase
    {
        private readonly IOutfitService _outfitService;

        public OutfitController(IOutfitService outfitService)
        {
            _outfitService = outfitService;
        }

        // GET: api/OutfitA/5
        [HttpGet("{temperature}")]
        public async Task<ActionResult<List<Outfit>>> GetOutfitByTemperature(double temperature)
        {
            var outfit = await _outfitService.GetCurrentWeatherOutfit(temperature);

            return outfit;
        }

        // POST: api/OutfitA
        [HttpPost]
        public async void AddOutfitToUserProfile(Outfit outfit)
        {
            _outfitService.AddOutfitToUserProfile(outfit);
        }

        // PUT: api/OutfitA/5
        [HttpPut("{id}")]
        public void UpdateUserOutfit(int id, Outfit outfit)
        {
            if (id > 8) // maybe add userId 999 as a condition check on default outfit.
            {
                _outfitService.UpdateUserOutfit(id, outfit);
                //return NoContent();
            }
        }

        // DELETE: api/OutfitA/5
        [HttpDelete("{id}")]
        public void DeleteUserOutfit(int id)
        {
            if (id > 8) // maybe add userId 999 as a condition check on default outfit.
            {
                _outfitService.DeleteUserOutfit(id);
                //return NoContent();
            }
        }

        //[HttpGet("{userId}")]
        //public async Task<ActionResult<List<Outfit>>> GetAllOutfitsByUserId(int userId)
        //{
        //    var outfits = await _outfitService.GetAllOutfitsByUserId(userId);
        //    return Ok(outfits);
        //}
    }
}