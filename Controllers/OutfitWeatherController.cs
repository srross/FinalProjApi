using FinalProjApi.Models;
using FinalProjApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutfitWeatherController : ControllerBase
    {
        private readonly IOutfitWeatherService _outfitWeatherService;

        public OutfitWeatherController(IOutfitWeatherService outfitWeatherService)
        {
            _outfitWeatherService = outfitWeatherService;
        }

        // GET: api/OutfitA/5
        [HttpGet("{temperature}")]
        public async Task<ActionResult<List<OutfitWeather>>> GetOutfitByTemperature(double temperature)
        {
            var outfitWeather = await _outfitWeatherService.GetCurrentWeatherOutfit(temperature);

            return outfitWeather;
        }

        // POST: api/OutfitA
        [HttpPost]
        public async void AddOutfitToUserProfile(OutfitWeather outfit)
        {
            _outfitWeatherService.AddOutfitToUserProfile(outfit);
        }

        // PUT: api/OutfitA/5
        [HttpPut("{id}")]
        public void UpdateUserOutfit(int id, OutfitWeather outfit)
        {
            if (id > 8) // maybe add userId 999 as a condition check on default outfit.
            {
                _outfitWeatherService.UpdateUserOutfit(id, outfit);
                //return NoContent();
            }
        }

        // DELETE: api/OutfitA/5
        [HttpDelete("{id}")]
        public void DeleteUserOutfit(int id)
        {
            if (id > 8) // maybe add userId 999 as a condition check on default outfit.
            {
                _outfitWeatherService.DeleteUserOutfit(id);
                //return NoContent();
            }
        }

        //[HttpGet("{userId}")]
        //public async Task<ActionResult<List<OutfitWeather>>> GetAllOutfitsByUserId(int userId)
        //{
        //    var outfits = await _outfitWeatherService.GetAllOutfitsByUserId(userId);
        //    return Ok(outfits);
        //}
    }
}