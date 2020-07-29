using CurrentWeather.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CurrentWeather.Services.ThirdParties.OpenWeather
{
    public interface IOpenWeatherService
    {
        void GetCurrentWeather(string city);
    }
    public class OpenWeatherService : IOpenWeatherService
    {
        private OpenWeatherConfig config;

        public OpenWeatherService()
        {
            config = ConfigHelper.GetConfigAs<OpenWeatherConfig>("OpenWeatherAPI");
        }
        public async void GetCurrentWeather(string city)
        {
            try
            {
                var URL = $"{config.CurrentWeatherURL}q={city}&appid={config.APIKey}";
                var requestSender = new HttpRequestSender();
                var response = await requestSender.Get(URL);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
