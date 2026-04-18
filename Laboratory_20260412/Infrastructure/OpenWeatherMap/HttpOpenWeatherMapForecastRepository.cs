using Laboratory_20260412.Application.Abstractions.Repositories;
using Laboratory_20260412.Domain.Entities;
using Laboratory_20260412.Infrastructure.OpenWeatherMap.Contracts;
using Laboratory_20260412.Infrastructure.OpenWeatherMap.Mappers;
using System.Net.Http.Json;

namespace Laboratory_20260412.Infrastructure.OpenWeatherMap;

public class HttpOpenWeatherMapForecastRepository : IForecastRepository
{
    private readonly HttpClient _client;
    private readonly OpenWeatherMapOptions _options;
    private readonly ICurrentWeatherResponseMapper _mapper;

    internal HttpOpenWeatherMapForecastRepository(HttpClient client, OpenWeatherMapOptions options, ICurrentWeatherResponseMapper mapper)
    {
        _client = client;
        _options = options;
        _mapper = mapper;
    }

    public async Task<Forecast?> GetCurrentByLocationAsync(Geolocation location, CancellationToken cancellationToken)
    {
        string uri = GetCurrentWeatherUriFor(location);

        if (await _client.GetFromJsonAsync<CurrentWeatherResponse>(uri, cancellationToken) is not { } response)
        {
            return null;
        }
        return _mapper.ToForecast(response);
    }

    private string GetCurrentWeatherUriFor(Geolocation location)
    {
        return $"/data/2.5/weather?lat={location.Latitude}&lon={location.Longitude}&appid={_options.Token}";
    }
}
