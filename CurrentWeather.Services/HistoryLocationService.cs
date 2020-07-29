using CurrentWeather.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CurrentWeather.Services
{
    public class HistoryLocationService
    {
        private string directoryPath = FileHelper.GetFileLocation();
        private string filename = "SavedLocations.txt";
        private string filePath;

        public HistoryLocationService()
        {
            filePath = directoryPath + "\\" + filename;
        }
        public void SaveLocation(string city, string country)
        {
            string[] fileContent = new string[0];

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            if(File.Exists(filePath))
                fileContent = File.ReadAllLines(filePath);
            if (!IsLocationAlreadySaved(city, country, fileContent))
                File.AppendAllText(Environment.NewLine + filePath, city + ", " + country);
        }

        public List<string> GetSavedLocations()
        {
            if (File.Exists(filePath))
                return File.ReadAllText(filePath).Split(Environment.NewLine).ToList();

            return new List<string>();
        }

        private bool IsLocationAlreadySaved(string city, string country, string[] content)
        {
            foreach(var line in content)
            {
                if (line == city + ", " + country)
                    return true;
            }

            return false;
        }
    }
}
