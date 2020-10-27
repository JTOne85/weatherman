using System.Text.Json.Serialization;

namespace Weatherman.Core.Entities
{
    public class Main
    {
        [JsonPropertyName("temp")] public float Temparature { get; set; }
        [JsonPropertyName("feels_like")] public float FeelsLike { get; set; }
        [JsonPropertyName("temp_min")] public float TempMin { get; set; }
        [JsonPropertyName("temp_max")] public int TempMax { get; set; }
        [JsonPropertyName("pressure")] public int Pressure { get; set; }
        [JsonPropertyName("humidity")] public int Humditiy { get; set; }
    }
}