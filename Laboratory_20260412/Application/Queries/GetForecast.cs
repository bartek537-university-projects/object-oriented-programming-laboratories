using Laboratory_20260412.Application.Abstractions.Interfaces;
using Laboratory_20260412.Application.Abstractions.Repositories;
using Laboratory_20260412.Domain.Entities;

namespace Laboratory_20260412.Application.Queries;

public static class GetForecast
{
    public sealed record Query(Geolocation Location) : IRequest<Response>;

    public sealed class Handler(IForecastRepository repository)
        : IRequestHandler<Query, Response>
    {
        public async Task<Response> HandleAsync(Query query, CancellationToken cancellationToken)
        {
            Forecast? forecast = await repository
                .GetCurrentByLocationAsync(query.Location, cancellationToken);

            return new Response(forecast);
        }
    }

    public sealed record Response(Forecast? Forecast);
}
