using System.Text.Json.Serialization;

namespace Weatherman.Core.Entities
{
    public abstract class Coord
    {
        [JsonPropertyName("lon")] public float Longitude { get; set; }
        [JsonPropertyName("lat")] public float Latitude { get; set; }
    }
}