using Laboratory_20260412.Domain.Entities;

namespace Laboratory_20260412.Application.Abstractions.Repositories;

public interface ICityRepository
{
    Task<IEnumerable<City>> GetCitiesByNameAsync(string name, int limit, CancellationToken cancellationToken);
    Task<IEnumerable<City>> GetCapitalsByContinentAsync(string continent, int limit, CancellationToken cancellationToken);
}
