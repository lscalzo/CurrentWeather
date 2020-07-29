using NLog;

namespace CurrentWeather.Helpers
{
    public static class LoggerHelper
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static Logger GetLogger()
        {
            return logger;
        }
    }
}
