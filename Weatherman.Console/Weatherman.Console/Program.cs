using System.Configuration;
using Weatherman.Core.Entities;
using Weatherman.Core.ExtensionMethods;
using Weatherman.Core.Services;

namespace Weatherman.Console
{
    public static class Program
    {
        private static string _displayFormatName = "json";
        private static readonly string ApiKey;

        static Program()
        {
            ApiKey = ConfigurationManager.AppSettings.Get("apiKey");
        }

        public static void Main(string[] args)
        {
            var shouldContinue = DisplayMenu();
            if (shouldContinue)
            {
                DisplayWeatherMenu();
            }
        }

        private static bool DisplayMenu()
        {
            System.Console.WriteLine(
                "Welcome to the Weather Service console app. Please select an option from the menu:");
            System.Console.WriteLine("(1.) Choose a city");
            System.Console.WriteLine("(2.) Exit");
            
            var success = int.TryParse(System.Console.ReadLine(), out _);
            if (success) return true;
            
            System.Console.WriteLine("Please use numbers as input");
            DisplayMenu();
            
            return false;
        }

        private static void DisplayWeatherMenu()
        {
            var (success, cityInput) = GetCityInput();
            if (!success)
            {
                System.Console.WriteLine("Please use the correct key to select data. 1 or 2");
                DisplayWeatherMenu();
            }
            else
            {
                switch (cityInput)
                {
                    case 1:
                        System.Console.WriteLine("Calling the weatherman...");
                        RetrieveDataFromOpenWeather("Cape Town");
                        break;
                    case 2:
                        System.Console.WriteLine("Have a good day!");
                        break;
                }
            }
        }

        private static void RetrieveDataFromOpenWeather(string location)
        {
            var displayFormat = GetDisplayFormat();
            var result = WeatherService.GetWeatherByStringLocation(location, ApiKey, displayFormat);
            switch (displayFormat)
            {
                case 2:
                    _displayFormatName = "XML";
                    break;
                case 3:
                    _displayFormatName = "formatted";
                    FormatWeatherForecast(result.Result);
                    break;
                case 4:
                {
                    _displayFormatName = "human readible";
                    GetShortWeatherForecast(result.Result);
                }
                    break;
            }

            if (displayFormat < 3)
            {
                System.Console.WriteLine($"Weather report in {_displayFormatName} format: \n {result.Result}");
            }
        }

        private static void GetShortWeatherForecast(string forecastRaw)
        {
            var shortWeatherString = FormattingService.GetShortWeatherForecast(forecastRaw).ToShortWeatherString();
            System.Console.Write(shortWeatherString);
        }

        private static void FormatWeatherForecast(string forecastRaw)
        {
            FormattingService.PrintFormattedObject(FormattingService.CreateFormattedWeatherForecast(forecastRaw));
        }

        private static (bool, int) GetCityInput()
        {
            System.Console.WriteLine("We currently only support Cape Town's weather");
            System.Console.WriteLine("(1.) Get Cape Town's current weather");
            System.Console.WriteLine("(2.) Exit");
            
            var success = int.TryParse(System.Console.ReadLine(), out var cityInput);
            return (success, cityInput);
        }
        
        private static int GetDisplayFormat()
        {
            System.Console.WriteLine("How would you like the result to be displayed?");
            System.Console.WriteLine("1. Raw JSON");
            System.Console.WriteLine("2. XML");
            System.Console.WriteLine("3. Formatted");
            System.Console.WriteLine("4. Nicely formatted and only displaying data that will be of interest to the public");
            var answer = System.Console.ReadLine();

            int.TryParse(answer, out var displayFormat);
            return displayFormat;
        }
    }
}