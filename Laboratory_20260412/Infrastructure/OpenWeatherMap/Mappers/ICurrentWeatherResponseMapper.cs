using Laboratory_20260412.Domain.Entities;
using Laboratory_20260412.Infrastructure.OpenWeatherMap.Contracts;

namespace Laboratory_20260412.Infrastructure.OpenWeatherMap.Mappers;

internal interface ICurrentWeatherResponseMapper
{
    Forecast ToForecast(CurrentWeatherResponse response);
}
