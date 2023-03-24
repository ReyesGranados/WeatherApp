using System.Collections.Generic;

namespace WeatherApp.Models
{
    public class LocationWeather
    {
        public string Title { get; set; }
        public string LocationType { get; set; }
        public string Woeid { get; set; }
        public string Time { get; set; }
        public string SunRise { get; set; }
        public string SunSet { get; set; }
        public string TimezoneName { get; set; }
        public List<Weather> ConsolidatedWeather { get; set; }
    }

    public class Weather
    {
        public string WeatherStateName { get; set; }
        public string WeatherStateAbbr { get; set; }
        public string WindDirectionCompass { get; set; }
        public string Created { get; set; }
        public string ApplicableDate { get; set; }
        public float MinTemp { get; set; }
        public float MaxTemp { get; set; }
        public float TheTemp { get; set; }
        public float WindSpeed { get; set; }
        public float WindDirection { get; set; }
        public float AirPressure { get; set; }
        public float Humidity { get; set; }
        public float Visibility { get; set; }
        public int Predictability { get; set; }
    }
}


