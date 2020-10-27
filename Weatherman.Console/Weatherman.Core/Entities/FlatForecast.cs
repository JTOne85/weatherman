namespace Weatherman.Core.Services
{
    public class FlatForecast
    {
        public float Temparature { get; set; }
        public float FeelsLike { get; set; }
        public float TempMin { get; set; }
        public float TempMax { get; set; }
        public int Pressure { get; set; }
        public int Humditiy { get; set; }
        public int CloudsAll { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public int Type { get; set; }
        public int SysId { get; set; }
        public string Country { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
        public int MainId { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public float WindSpeed { get; set; }
        public int WindDegrees { get; set; }
    }
}