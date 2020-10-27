using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Weatherman.Core.Entities;
using Weatherman.Core.ExtensionMethods;


namespace Weatherman.Core.Services
{
    public static class FormattingService
    {
        public static RootObject CreateFormattedWeatherForecast(string forecastRaw)
        {
            var weatherForecast = JsonSerializer.Deserialize<RootObject>(forecastRaw);
            return weatherForecast;
        }

        public static void PrintFormattedObject(RootObject weatherForecast)
        {
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(weatherForecast))
            {
                var name = descriptor.Name;
                var value = descriptor.GetValue(weatherForecast);
                System.Console.WriteLine($"{name.PadRight(12)}: {value}");
            }
        }

        public static void GetShortWeatherForecast(string forecastRaw)
        {
            var weatherForecast = JsonSerializer.Deserialize<RootObject>(forecastRaw);

            var shortForecast = new ShortWeatherForecast
            {
                Main = weatherForecast.Weather[0].Main,
                Description = weatherForecast.Weather[0].Description,
                Icon = weatherForecast.Weather[0].Icon,
                MinimumTemp = weatherForecast.Main.TempMin,
                MaximumTemp = weatherForecast.Main.TempMax,
                CurrentTemp = weatherForecast.Main.Temparature,
                FeelsLike = weatherForecast.Main.FeelsLike,
                Humidity = weatherForecast.Main.Humditiy,
                WindSpeed = weatherForecast.Wind.Speed,
                WindDirection = DetermineDirectionFromDegrees(weatherForecast.Wind.Deg),
                Sunrise = GetDateTime(weatherForecast.Sys.Sunrise),
                Sunset = GetDateTime(weatherForecast.Sys.Sunset),
                Name = weatherForecast.Name,
                CurrentTime = GetDateTime(weatherForecast.Date)
            };
        }

        private static DateTime GetDateTime(int unixTime)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dateTime.AddSeconds(unixTime).ToLocalTime();
        }

        private static string DetermineDirectionFromDegrees(int windDeg)
        {
            var value = (int) (windDeg / 22.5 + 0.5);
            var index = (value % 16);
            // var windDirections = new[]
            //     {"N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW"};
            // return windDirections[index];
            var direction = (WindDirections) index;
            var desc = direction.GetDescription();
            return desc;
        }
    }

    public enum WindDirections
    {
        [Description("North")] N = 0,
        [Description("North North-East")] NNE = 1,
        [Description("North-East")] NE = 2,
        [Description("East North East")] ENE = 3,
        [Description("East")] E = 4,
        [Description("East South East")] ESE = 5,
        [Description("South East")] SE = 6,
        [Description("South South East")] SSE = 7,
        [Description("South")] S = 8,
        [Description("South South West")] SSW = 9,
        [Description("South West")] SW = 10,
        [Description("West South West")] WSW = 11,
        [Description("West")] W = 12,
        [Description("West North West")] WNW = 13,
        [Description("North West")] NW = 14,
        [Description("North North West")] NNW = 15
    }
}