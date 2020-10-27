using System;
using System.Globalization;
using System.Text;
using Weatherman.Core.Entities;

namespace Weatherman.Core.ExtensionMethods
{
    public static class ShortWeatherForecastExtensions
    {
        public static string ToShortWeatherString(this ShortWeatherForecast forecast)
        {
            var stringBuilder = new StringBuilder();
            var now = DateTime.Now;
            var midday = new TimeSpan(12, 0, 0);
            var evening = new TimeSpan(18, 0, 0);

            var salutation = GetSalutation(now, evening, midday);
            stringBuilder.AppendLine($"{salutation}, here is the current weather forecast at {forecast.CurrentTime:dddd, d MMMM, yyyy} for {forecast.Name}");
            stringBuilder.AppendLine($"The current temperature is: {forecast.CurrentTemp}°C, " +
                                     $"the minimum is {Math.Round(forecast.MinimumTemp)}°C with a maximum of " +
                                     $"{Math.Round(forecast.MaximumTemp)}°C and it feels like {Math.Round(forecast.FeelsLike)}°C");
            stringBuilder.AppendLine();
            GetWindReading(forecast, stringBuilder);
            GetSunriseOrSunset(forecast, now, stringBuilder);
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("Please enjoy the rest of your day");

            return stringBuilder.ToString();
        }

        private static void GetSunriseOrSunset(ShortWeatherForecast forecast, DateTime now, StringBuilder stringBuilder)
        {
            if (IsAfterSunrise(now, forecast.Sunrise))
            {
                stringBuilder.AppendLine(!IsAfterSunset(now, forecast.Sunset)
                    ? $"Sunset will be at {forecast.Sunset.TimeOfDay}"
                    : $"Sunrise will be at {forecast.Sunrise.TimeOfDay}");
            }
        }

        private static void GetWindReading(ShortWeatherForecast forecast, StringBuilder stringBuilder)
        {
            stringBuilder.AppendLine(forecast.WindSpeed > 0
                ? $"There is currently a wind of {Math.Round(forecast.WindSpeed * 3.6, 2)} km/h  blowing {forecast.WindDirection}"
                : "There there is currently no wind");
        }

        private static string GetSalutation(DateTime now, TimeSpan evening, TimeSpan midday)
        {
            var salutation = "Good day,";
            if (now.TimeOfDay >= evening)
            {
                salutation = "Good evening";
            }
            else if (now.TimeOfDay >= midday)
            {
                salutation = "Good afternoon";
            }
            else
            {
                salutation = "Good morning";
            }

            return salutation;
        }

        private static bool IsAfterSunrise(in DateTime now, in DateTime sunrise)
        {
            return now >= sunrise;
        }

        private static bool IsAfterSunset(DateTime now, DateTime sunset)
        {
            return now >= sunset;
        }
    }
}