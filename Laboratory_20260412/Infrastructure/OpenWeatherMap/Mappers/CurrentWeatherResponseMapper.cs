using Laboratory_20260412.Domain.Entities;
using Laboratory_20260412.Infrastructure.OpenWeatherMap.Contracts;
using static Laboratory_20260412.Domain.Entities.WeatherConditions;

namespace Laboratory_20260412.Infrastructure.OpenWeatherMap.Mappers;

internal class CurrentWeatherResponseMapper : ICurrentWeatherResponseMapper
{
    public Forecast ToForecast(CurrentWeatherResponse response)
    {
        Forecast forecast = new(
            Weather: ToWeatherConditions(response.Weather),
            Temperature: ToTemperatureConditions(response.Main),
            Atmospheric: ToAtmosphericConditions(response.Main),
            Wind: ToWindConditions(response.Wind),
            Rain: ToRainConditions(response.Rain)
        );

        return forecast;
    }

    private static WeatherConditions ToWeatherConditions(IEnumerable<CurrentWeatherResponse.WeatherConditions> conditions)
    {
        if (conditions.FirstOrDefault() is not { } weather)
        {
            throw new ArgumentException("No weather details present.");
        }

        return weather.Id switch
        {
            >= 200 and < 300 => Thunderstorm,
            >= 300 and < 400 => Drizzle,
            >= 500 and < 600 => Rain,
            >= 600 and < 700 => Snow,
            >= 700 and < 800 => Mist,
            800 => Clear,
            >= 801 and < 900 => Clouds,
            _ => throw new ArgumentException("Unknown weather conditions.", paramName: nameof(conditions))
        };
    }

    private static TemperatureConditions ToTemperatureConditions(CurrentWeatherResponse.AtmosphericConditions conditions)
    {
        return new(
            Current: conditions.CurrentTemperature,
            Minimum: conditions.MinimumTemperature,
            Maximum: conditions.MaximumTemperature
        );
    }

    private static AtmosphericConditions ToAtmosphericConditions(CurrentWeatherResponse.AtmosphericConditions conditions)
    {
        return new(
            Pressure: conditions.Pressure,
            Humidity: conditions.Humidity
        );
    }

    private static WindConditions ToWindConditions(CurrentWeatherResponse.WindConditions conditions)
    {
        return new(
            Speed: conditions.Speed,
            Angle: conditions.Direction
        );
    }

    private static RainConditions? ToRainConditions(CurrentWeatherResponse.RainConditions? conditions)
    {
        if (conditions is null)
        {
            return null;
        }

        return new(
            NextHour: conditions.NextHour
        );
    }
}
