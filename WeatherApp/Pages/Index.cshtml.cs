using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public IndexModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public IList<Weather> ConsolidatedWeather { get; set; }

        public async Task<IActionResult> OnGetAsync(string woeid)
        {
            if (string.IsNullOrEmpty(woeid) && !Request.Query.ContainsKey("woeid"))
            {
                // No WOEID provided, show message to enter a WOEID
                return Page();
            }

            woeid = woeid ?? Request.Query["woeid"];

            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:5001/Weather/{woeid}");
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                ConsolidatedWeather = JsonConvert.DeserializeObject<List<Weather>>(stringResponse);
            }

            return Page();
        }

    }
}



