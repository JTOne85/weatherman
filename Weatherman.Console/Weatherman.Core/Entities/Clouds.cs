using System.Text.Json.Serialization;

namespace Weatherman.Core.Entities
{
    public class Clouds
    {
        [JsonPropertyName("all")] public int All { get; set; }
    }
}