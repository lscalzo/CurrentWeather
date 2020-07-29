using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrentWeather.Services.ThirdParties.OpenWeather.Models
{
    public class CurrentWeatherResponse
    {
        [JsonProperty("coord")]
        public Coord Coord { get; set; }

        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("visibility")]
        public int Visibility { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("dt")]
        public int Dt { get; set; }

        [JsonProperty("sys")]
        public Sys Sys { get; set; }

        [JsonProperty("timezone")]
        public int Timezone { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cod")]
        public int Cod { get; set; }

        public string FormatForConsole()
        {
            if (Cod == 404)
                return "We couldn't find the city you're looking for";
            else
                return $"The weather in {Name}, {Sys.Country} is :{Environment.NewLine}" +
                $"Description : {Weather.First().Description}{Environment.NewLine}" +
                $"Temperature : {Main.Temp}°C{Environment.NewLine}" +
                $"Wind : {Wind.Speed} m/s from {Wind.Deg}";
        }
    }


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Coord
    {

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

    }

    public class Weather
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("main")]
        public string Main { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

    }

    public class Main
    {

        [JsonProperty("temp")]
        public decimal Temp { get; set; }

        [JsonProperty("feels_like")]
        public double FeelsLike { get; set; }

        [JsonProperty("temp_min")]
        public double TempMin { get; set; }

        [JsonProperty("temp_max")]
        public double TempMax { get; set; }

        [JsonProperty("pressure")]
        public int Pressure { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }

    }

    public class Wind
    {

        [JsonProperty("speed")]
        public decimal Speed { get; set; }

        [JsonProperty("deg")]
        public int Deg { get; set; }

    }

    public class Clouds
    {

        [JsonProperty("all")]
        public int All { get; set; }

    }

    public class Sys
    {

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("message")]
        public double Message { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("sunrise")]
        public int Sunrise { get; set; }

        [JsonProperty("sunset")]
        public int Sunset { get; set; }

    }
}
