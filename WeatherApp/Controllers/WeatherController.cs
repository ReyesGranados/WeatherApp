using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public WeatherController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet("{woeid}")]
        public async Task<IActionResult> GetWeather(string woeid)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://www.metaweather.com/api/location/{woeid}/");
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                var locationWeather = JsonConvert.DeserializeObject<LocationWeather>(stringResponse);
                return Ok(locationWeather.ConsolidatedWeather);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}


