using System.Text.Json.Serialization;

namespace Weatherman.Core.Entities
{
    public class Wind
    {
        [JsonPropertyName("speed")] public float Speed { get; set; }
        [JsonPropertyName("deg")] public int Deg { get; set; }
    }
}