using Laboratory_20260412.Domain.Entities;

namespace Laboratory_20260412.Application.Abstractions.Repositories;

public interface IForecastRepository
{
    Task<Forecast?> GetCurrentByLocationAsync(Geolocation location, CancellationToken cancellationToken);
}
