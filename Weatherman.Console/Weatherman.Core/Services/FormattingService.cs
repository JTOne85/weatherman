using System;
using System.ComponentModel;
using System.Text.Json;
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
            var direction = (WindDirections) index;
            
            return direction.GetDescription();
            
        }
    }
}