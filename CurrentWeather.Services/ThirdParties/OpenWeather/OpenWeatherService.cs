using System;
using System.Collections.Generic;
using System.Text;

namespace CurrentWeather.Services.ThirdParties.OpenWeather
{
    public interface IOpenWeatherService
    {
        void GetCurrentWeather(string city);
    }
    public class OpenWeatherService : IOpenWeatherService
    {
        public void GetCurrentWeather(string city)
        {
            throw new NotImplementedException();
        }
    }
}
