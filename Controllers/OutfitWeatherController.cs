using FinalProjApi.Models;
using FinalProjApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
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

        //[HttpGet("{temperature}")]
        //public async Task<OutfitWeather> GetOutfitByTemperature(double temperature)
        //{
        //    //List<OutfitWeather> listOutfits = new List<OutfitWeather>();

        //    return _outfitWeatherService.GetCurrentWeatherOutfit(temperature);


        //}

        // GET: api/OutfitA/5
        [HttpGet("{temperature}")]
        public async Task<ActionResult<List<OutfitWeather>>> GetOutfitByTemperature(double temperature)
        {
            //if (_context.Outfits == null)
            //{
            //    return NotFound();
            //}
            var outfitWeather = await _outfitWeatherService.GetCurrentWeatherOutfit(temperature);

            //if (outfitWeather == null)
            //{
            //    return NotFound();
            //}

            return outfitWeather;
        }

        //[HttpGet("{userId}")]
        //public async Task<ActionResult<List<OutfitWeather>>> GetAllOutfitsByUserId(int userId)
        //{
        //    var outfits = await _outfitWeatherService.GetAllOutfitsByUserId(userId);
        //    return Ok(outfits);
        //}
    }
}