namespace Laboratory_20260412.Infrastructure.OpenWeatherMap;

public class OpenWeatherMapOptions
{
    public const string Section = "OpenWeatherMap";

    public required Uri BaseUrl { get; set; }
    public required string Token { get; set; }
}
