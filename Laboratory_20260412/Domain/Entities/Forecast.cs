namespace Laboratory_20260412.Domain.Entities;

public record Forecast(
    WeatherConditions Weather,
    TemperatureConditions Temperature,
    AtmosphericConditions Atmospheric,
    WindConditions Wind,
    RainConditions? Rain
);

public enum WeatherConditions
{
    Thunderstorm,
    Drizzle,
    Rain,
    Snow,
    Mist,
    Clear,
    Clouds,
}

public record TemperatureConditions(
    double Current, double Minimum, double Maximum
);

public record AtmosphericConditions(
    double Pressure, double Humidity
);

public record WindConditions(
    double Speed, double Angle
);

public record RainConditions(
    double NextHour
);