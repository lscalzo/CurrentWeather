using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace CurrentWeather.Helpers
{
    public static class ConfigHelper
    {
        public static IConfigurationRoot configuration;
        public static void InitializeConfig()
        {
            configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("appsettings.json", false)
            .Build();
        }

        public static T GetConfigAs<T>(string sectionName) where T : new()
        {
            T config = new T();
            var section = configuration.GetSection(sectionName);
            section.Bind(config);
            return config;
        }
    }
}
