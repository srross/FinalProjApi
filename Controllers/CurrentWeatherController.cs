using FinalProjApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentWeatherController : BaseController
    {
        private IAccuWeatherService _accuWeatherService;
        public CurrentWeatherController(IAccuWeatherService accuWeatherService)
        {
            _accuWeatherService = accuWeatherService;
        }


        // GET api/<CurrentWeatherController>/5
        [HttpGet("{zipCode}")]
        public async Task<IActionResult> GetWeather(string zipCode)
        {

            var Current_Weather = await _accuWeatherService.GetCurrentWeather(zipCode);
            

            return Ok(Current_Weather);
        }

    }
}
