using Laboratory_20260412.Application.Abstractions.Repositories;
using Laboratory_20260412.Domain.Entities;
using Laboratory_20260412.Infrastructure.OpenDataSoft.Contracts;
using Laboratory_20260412.Infrastructure.OpenDataSoft.Mappers;
using System.Net.Http.Json;

namespace Laboratory_20260412.Infrastructure.OpenDataSoft;

public class HttpOpenDataSoftGeonamesRepository : ICityRepository
{
    private const string DatasetUri = $"api/explore/v2.1/catalog/datasets/geonames-all-cities-with-a-population-1000";

    private readonly HttpClient _client;
    private readonly IGeonameResponseMapper _mapper;

    internal HttpOpenDataSoftGeonamesRepository(HttpClient client, IGeonameResponseMapper mapper)
    {
        _client = client;
        _mapper = mapper;
    }

    public Task<IEnumerable<City>> GetCitiesByNameAsync(string name, int limit, CancellationToken cancellationToken)
    {
        return GetCitiesByUriAsync(CreateGetCitiesByNameUri(name, limit), cancellationToken);
    }

    public Task<IEnumerable<City>> GetLargestCapitalsByContinentAsync(string continent, int limit, CancellationToken cancellationToken)
    {
        return GetCitiesByUriAsync(CreateGetCapitalsByContinentUri(continent, limit), cancellationToken);
    }

    private async Task<IEnumerable<City>> GetCitiesByUriAsync(string uri, CancellationToken cancellationToken)
    {
        if (await _client.GetFromJsonAsync<GeonamesResponse>(uri, cancellationToken) is not { } response)
        {
            throw new InvalidDataException("Failed to parse server response.");
        }

        return _mapper.ToCities(response);
    }

    private static string CreateGetCitiesByNameUri(string name, int limit = 20)
    {
        return $"{DatasetUri}/records" +
            $"?select=name, country_code, coordinates" +
            $"&where=name like \"*{name}*\"" +
            $"&order_by=population desc" +
            $"&limit={limit}";
    }

    private static string CreateGetCapitalsByContinentUri(string continent, int limit = 20)
    {
        return $"{DatasetUri}/records" +
            $"?select=name, country_code, coordinates" +
            $"&where=timezone like \"{continent}*\" and feature_code = \"PPLC\"" +
            $"&order_by=population desc" +
            $"&limit={limit}";
    }
}
