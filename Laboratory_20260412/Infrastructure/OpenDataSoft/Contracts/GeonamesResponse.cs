using System.Text.Json.Serialization;

namespace Laboratory_20260412.Infrastructure.OpenDataSoft.Contracts;

public class GeonamesResponse
{
    [JsonPropertyName("results")]
    public required IEnumerable<City> Results { get; set; }

    public class City
    {
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("cou_name_en")]
        public required string Country { get; set; }

        [JsonPropertyName("coordinates")]
        public required Coordinates Coordinates { get; set; }
    }

    public class Coordinates
    {
        [JsonPropertyName("lat")]
        public required double Latitude { get; set; }

        [JsonPropertyName("lon")]
        public required double Longitude { get; set; }
    }
}
