using FinalProjApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationFinderController : ControllerBase
    {
        private IAccuWeatherService _accuWeatherService;
        public LocationFinderController(IAccuWeatherService accuWeatherService)
        {
            _accuWeatherService = accuWeatherService;
        }


        // GET api/<LocationFinderController>/5
        [HttpGet("{zipCode}")]
        public async Task<IActionResult> GetWeather(string zipCode)
        {
            await _accuWeatherService.GetLocationKey(zipCode);
            

            return Ok();
        }

    }
}
