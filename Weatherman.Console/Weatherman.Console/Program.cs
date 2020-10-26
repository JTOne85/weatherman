using System.Configuration;
using System.Threading.Tasks;
using Weatherman.Core.Services;

namespace Weatherman.Console
{
    public class Program
    {
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
            System.Console.WriteLine("Welcome to the Weather Service console app. Please select an option from the menu:");
            System.Console.WriteLine("(1.) Choose a city");
            System.Console.WriteLine("(2.) Exit");
            int inputValue;
            var success = int.TryParse(System.Console.ReadLine(), out inputValue);
            if (!success)
            {
                System.Console.WriteLine("Please use numbers as input");
                DisplayMenu();
            }

            return success;
        }

        private static void DisplayWeatherMenu()
        {
            System.Console.WriteLine("We currently only support Cape Town's weather");
            System.Console.WriteLine("(1.) Cape Town");
            System.Console.WriteLine("(2.) Exit");
            var input = System.Console.ReadLine();
            int cityInput;
            var success = int.TryParse(input, out cityInput);
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
                    default:
                        break;
                }
            }
        }

        private static void RetrieveDataFromOpenWeather(string location)
        {
            System.Console.WriteLine("How would you like the result to be displayed?");
            System.Console.WriteLine("1. JSON");
            System.Console.WriteLine("2. XML");
            System.Console.WriteLine("3. Human readible");
            System.Console.WriteLine("4. Just the useful stuff, please");
            var answer = System.Console.ReadLine();

            int displayFormat;
            int.TryParse(answer, out displayFormat);

            var apiKey = ConfigurationManager.AppSettings.Get("apiKey");
            var result = WeatherService.GetWeatherByStringLocation(location, apiKey);

            switch (displayFormat)
            {
                case 1:
                    System.Console.WriteLine($"Weather report: \n {result.Result}");
                    break;
                case 2: break;
                case 3: break;
                case 4: break;
                default: break;
            }
            
        }
    }
}