using System;
using System.ComponentModel;
using System.Text.Json;
using Weatherman.Core.Entities;
using Weatherman.Core.ExtensionMethods;


namespace Weatherman.Core.Services
{
    public class FormattingService
    {
        public static void PrintFormattedObject<T>(T weatherForecast) where T : class
        {
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(weatherForecast))
            {
                var name = descriptor.Name;
                var value = descriptor.GetValue(weatherForecast);
                Console.WriteLine($"{name.PadRight(12)}: {value}");
            }
        }

        public static ShortWeatherForecast GetShortWeatherForecast(string forecastRaw)
        {
            var weatherForecast = JsonSerializer.Deserialize<RootObject>(forecastRaw);

            return new ShortWeatherForecast
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

        public static FlatForecast ConvertToFlatFullWeatherForecast(string forecastRaw)
        {
            var forecast = CreateFormattedWeatherForecast(forecastRaw);
            return new FlatForecast
            {
                Country = forecast.Sys.Country,
                Sunrise = forecast.Sys.Sunrise,
                Sunset = forecast.Sys.Sunset,
                SysId = forecast.Sys.Id,
                Type = forecast.Sys.Type,
                CloudsAll = forecast.Clouds.All,
                Longitude = forecast.Coordinates.Longitude,
                Latitude = forecast.Coordinates.Latitude,
                Humditiy = forecast.Main.Humditiy,
                Temparature = forecast.Main.Temparature,
                Pressure = forecast.Main.Pressure,
                TempMax = forecast.Main.TempMax,
                TempMin = forecast.Main.TempMin,
                FeelsLike = forecast.Main.FeelsLike,
                MainId = forecast.Weather[0].Id,
                Main = forecast.Weather[0].Main,
                Description = forecast.Weather[0].Description,
                WindDegrees = forecast.Wind.Deg,
                WindSpeed = forecast.Wind.Speed,
                Icon = forecast.Weather[0].Icon
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

        private static RootObject CreateFormattedWeatherForecast(string forecastRaw)
        {
            var weatherForecast = JsonSerializer.Deserialize<RootObject>(forecastRaw);
            return weatherForecast;
        }
    }
}