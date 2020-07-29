using CurrentWeather.Helpers;
using CurrentWeather.Services.ThirdParties.OpenWeather.Models;
using NLog;
using System;
using System.Threading.Tasks;

namespace CurrentWeather.Services.ThirdParties.OpenWeather
{
    public interface IOpenWeatherService
    {
        Task<string> GetCurrentWeather(string city, string country);
    }
    public class OpenWeatherService : IOpenWeatherService
    {
        private OpenWeatherConfig config { get; set; }
        private HistoryLocationService historyService { get; set; }
        private static Logger logger = LoggerHelper.GetLogger();

        public OpenWeatherService()
        {
            config = ConfigHelper.GetConfigAs<OpenWeatherConfig>("OpenWeatherAPI");
            historyService = new HistoryLocationService();
        }
        public async Task<string> GetCurrentWeather(string city, string country)
        {
            try
            {
                var URL = $"{config.CurrentWeatherURL}q={city},{country}&appid={config.APIKey}&units=metric";
                var requestSender = new HttpRequestSender();
                var response = await requestSender.GetAs<CurrentWeatherResponse>(URL);
                if(response.Cod != 404)
                    historyService.SaveLocation(city, country);

                return response.FormatForConsole() ;
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                throw;
            }
        }
    }
}
