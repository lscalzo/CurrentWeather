using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CurrentWeather.Helpers
{
    public static class FileHelper
    {
        public static string GetFileLocation()
        {
            var systemPath = System.Environment.
                             GetFolderPath(
                                 Environment.SpecialFolder.CommonApplicationData
                             );
            return Path.Combine(systemPath, "CurrentWeather");
        }
    }
}
