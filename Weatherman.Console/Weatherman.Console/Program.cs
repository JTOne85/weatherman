using System;

namespace Weatherman.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int inputValue = 0;
            var shouldContinue = DisplayMenu(out inputValue);
            if (shouldContinue)
            {
                DisplayWeatherMenu();
            }
        }

        private static bool DisplayMenu(out int inputValue)
        {
            System.Console.WriteLine(
                "Welcome to the Weather Service console app. Please select an option from the menu:");
            System.Console.WriteLine("(1.) Choose a city");
            System.Console.WriteLine("(2.) Exit");
            var success = int.TryParse(System.Console.ReadLine(), out inputValue);
            if (!success)
            {
                System.Console.WriteLine("Please use numbers as input");
            }

            return success;
        }

        private static void DisplayWeatherMenu()
        {
            var cityInput = 0;
            System.Console.WriteLine("We currently only support Cape Town's weather");
            System.Console.WriteLine("(1.) Cape Town");
            System.Console.WriteLine("(2.) Exit");
            if (!int.TryParse(System.Console.ReadLine(), out cityInput))
            {
                System.Console.WriteLine("Please use the correct key to select data. 1 or 2");
                DisplayWeatherMenu();
            }

            else if (cityInput == 2)
            {
                System.Console.WriteLine("Have a good day!");
            }
            else
            {
                System.Console.WriteLine("Calling the weatherman...");
                // call the weather api here
            }
            
        }
}

}