using Laboratory_20260412.Domain.Entities;
using Laboratory_20260412.Infrastructure.OpenDataSoft.Contracts;

namespace Laboratory_20260412.Infrastructure.OpenDataSoft.Mappers;

public interface IGeonameResponseMapper
{
    IEnumerable<City> ToCities(GeonamesResponse response);
}
