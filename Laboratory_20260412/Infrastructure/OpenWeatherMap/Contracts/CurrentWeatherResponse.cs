using System.Text.Json.Serialization;

namespace Laboratory_20260412.Infrastructure.OpenWeatherMap.Contracts;

internal class CurrentWeatherResponse
{
    [JsonPropertyName("weather")]
    public required IEnumerable<WeatherConditions> Weather { get; set; }

    [JsonPropertyName("main")]
    public required AtmosphericConditions Main { get; set; }

    [JsonPropertyName("wind")]
    public required WindConditions Wind { get; set; }

    [JsonPropertyName("rain")]
    public RainConditions? Rain { get; set; }

    [JsonPropertyName("dt")]
    public required long Timestamp { get; set; }

    internal class WeatherConditions
    {
        [JsonPropertyName("id")]
        public required int Id { get; set; }
    }

    internal class AtmosphericConditions
    {
        [JsonPropertyName("temp")]
        public required double CurrentTemperature { get; set; }

        [JsonPropertyName("temp_min")]
        public required double MinimumTemperature { get; set; }

        [JsonPropertyName("temp_max")]
        public required double MaximumTemperature { get; set; }

        [JsonPropertyName("pressure")]
        public required double Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public required double Humidity { get; set; }
    }

    internal class WindConditions
    {
        [JsonPropertyName("speed")]
        public required double Speed { get; set; }

        [JsonPropertyName("deg")]
        public required double Direction { get; set; }
    }

    internal class RainConditions
    {
        [JsonPropertyName("1h")]
        public required double NextHour { get; set; }
    }
}
