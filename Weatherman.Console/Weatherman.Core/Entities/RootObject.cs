using System.Text.Json.Serialization;

namespace Weatherman.Core.Entities
{
    public class RootObject
    {
        [JsonPropertyName("coord")] public Coord Coordinates { get; set; }
        [JsonPropertyName("weather")] public Weather[] Weather { get; set; }
        [JsonPropertyName("base")] public string Base { get; set; }
        [JsonPropertyName("main")] public Main Main { get; set; }
        [JsonPropertyName("visibility")] public int Visibility { get; set; }
        [JsonPropertyName("wind")] public Wind Wind { get; set; }
        [JsonPropertyName("clouds")] public Clouds Clouds { get; set; }
        [JsonPropertyName("dt")] public int Date { get; set; }
        [JsonPropertyName("sys")] public Sys Sys { get; set; }
        [JsonPropertyName("timezone")] public int Timezone { get; set; }
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("cod")] public int Cod { get; set; }
    }
}