using Laboratory_20260412.Domain.Entities;
using Laboratory_20260412.Infrastructure.OpenDataSoft.Contracts;

namespace Laboratory_20260412.Infrastructure.OpenDataSoft.Mappers;

internal class GeonameResponseMapper : IGeonameResponseMapper
{
    public IEnumerable<City> ToCities(GeonamesResponse response)
    {
        return response.Results.Select(ToCity);
    }

    private static City ToCity(GeonamesResponse.City city)
    {
        return new(
            Name: city.Name,
            CountryCode: city.CountryCode,
            Location: ToGeolocation(city.Coordinates)
        );
    }

    private static Geolocation ToGeolocation(GeonamesResponse.Coordinates coordinates)
    {
        return new(
            Latitude: coordinates.Latitude,
            Longitude: coordinates.Longitude
        );
    }
}
