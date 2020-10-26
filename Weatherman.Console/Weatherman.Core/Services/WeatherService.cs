using System;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Weatherman.Core.Services
{
    public class WeatherService
    {
        public static async Task<string> GetWeatherByStringLocation(string location, string apiKey)
        {
            var encodedLocation = location.Replace(" ", "%20");
            var baseUrl = $"http://api.openweathermap.org/data/2.5/weather?q={encodedLocation}&appid={apiKey}";
            var httpClient = new HttpClient();
            var blah =  httpClient.GetAsync(baseUrl).Result;
            blah.EnsureSuccessStatusCode();
            string responseBody = await blah.Content.ReadAsStringAsync();
            return responseBody;
        }

    }
}
