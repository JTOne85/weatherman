using System;
using System.Configuration;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Weatherman.Core.Services
{
    public class WeatherService
    {
        public static async Task<string> GetWeatherByStringLocation(string location, string apiKey)
        {
            var baseUrl = ConfigurationManager.AppSettings.Get("openWeatherUrl");

            var httpClient = new HttpClient();
            var response = httpClient.GetAsync($"{baseUrl}?q={location}&appid={apiKey}").Result;
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
            
            
        }

    }
}
