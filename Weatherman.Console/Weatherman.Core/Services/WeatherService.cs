using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace Weatherman.Core.Services
{
    public class WeatherService
    {
        public static async Task<string> GetWeatherByStringLocation(string location, string apiKey, int displayFormat)
        {
            var url = BuildUrlWithMode(location, apiKey, displayFormat);
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            
            return await response.Content.ReadAsStringAsync();
        }

        private static string BuildUrlWithMode(string location, string apiKey, int displayFormat)
        {
            var baseUrl = ConfigurationManager.AppSettings.Get("openWeatherUrl");
            var url = $"{baseUrl}?q={location}&appid={apiKey}&units=metric";

            switch (displayFormat)
            {
                case 1:
                case 3:
                case 4:
                    break;
                case 2:
                    url += "&mode=xml";
                    break;
            }

            return url;
        }
    }
}