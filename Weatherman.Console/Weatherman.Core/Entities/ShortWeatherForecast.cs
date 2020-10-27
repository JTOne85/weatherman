using System;

namespace Weatherman.Core.Entities
{
    public class ShortWeatherForecast
    {
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public float MinimumTemp { get; set; }
        public int MaximumTemp { get; set; }
        
        public float CurrentTemp {get;set;}
        public float FeelsLike { get; set; }
        public int Humidity { get; set; }
        public float WindSpeed { get; set; }
        public string WindDirection { get; set; }
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
        public string Name { get; set; }
        public DateTime CurrentTime { get; set; }
    }
}