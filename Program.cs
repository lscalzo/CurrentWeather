
using CurrentWeather.Helpers;
using CurrentWeather.Services;
using CurrentWeather.Services.ThirdParties.OpenWeather;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast
{
    class Program
    {
        private static Logger logger = LoggerHelper.GetLogger();
        static async Task Main(string[] args)
        {
            try
            {
                ConfigHelper.InitializeConfig();
                var weatherService = new OpenWeatherService();

                var historyService = new HistoryLocationService();
                var history = historyService.GetSavedLocations();

                Console.WriteLine("Please enter the name of a city and iso country code separated by a comma, example : Perth, AU");
                DisplayHistory(history);
                var input = Console.ReadLine().Trim();
                string city;
                string country;
                ValidateInput(input, history, out city, out country);
                var currentWeather = await weatherService.GetCurrentWeather(city.Trim(' '), country?.Trim(' ').ToUpper());
                Console.WriteLine(currentWeather);
                while (currentWeather.Contains("We couldn't find"))
                {
                    Console.WriteLine("Please enter another city name or a number from the list.");
                    input = Console.ReadLine();
                    ValidateInput(input, history, out city, out country);
                    currentWeather = await weatherService.GetCurrentWeather(city.Trim(' '), country?.Trim(' ').ToUpper());
                }
                Console.WriteLine(currentWeather);
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
            
        }

        private static void ValidateInput(string input, List<string> history, out string city, out string country)
        {
            while (!ParseInput(input, history, out city, out country))
            {
                Console.WriteLine("The number you entered is incorrect, please enter a number from the list below.");
                DisplayHistory(history);
                input = Console.ReadLine();
            }
        }

        private static void DisplayHistory(List<string> history)
        {
            if (history.Count > 0)
            {
                Console.WriteLine("You looked up the current weather of a city before, you can also enter the city number from the list below to get it's current weather again.");
                for (int i = 0; i < history.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + history.ElementAt(i));
                }
            }
        }

        private static bool ParseInput(string input, List<string> history, out string city, out string country)
        {
            city = null;
            country = null;
            int historyIndex;
            if (int.TryParse(input, out historyIndex))
            {
                if (historyIndex > history.Count)
                    return false;
                var historyItem = history.ElementAt(historyIndex - 1);
                GetSearchData(historyItem, out city, out country);
            }
            else
            {
                GetSearchData(input, out city, out country);
            }
            return true;
        }

        private static void GetSearchData(string input, out string city, out string country)
        {
            city = null;
            country = null;

            var items = input.Split(',');
            if(items.Length == 1)
            {
                city = input;
            }
            if (items.Length == 2)
            {
                city = items[0];
                country = items[1];
            }
            if (items.Length > 2)
            {
                throw new Exception("Your input is invalid, you can't have more than 1 comma.");
            }
        }
    }

}
