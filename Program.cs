
using CurrentWeather.Helpers;
using CurrentWeather.Services.ThirdParties.OpenWeather;
using System;

namespace WeatherForecast
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigHelper.InitializeConfig();
            var weatherService = new OpenWeatherService();
            Console.WriteLine("Please enter the name of a city");
            var city = Console.ReadLine();
            weatherService.GetCurrentWeather(city);
            Console.ReadLine();
        }
    }

}
