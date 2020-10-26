using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;

using Weatherman.Core.Entities;

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
    }
}