using Laboratory_20260412.Application.Abstractions.Interfaces;
using Laboratory_20260412.Application.Abstractions.Repositories;
using Laboratory_20260412.Domain.Entities;

namespace Laboratory_20260412.Application.Queries;

public static class GetCitiesByName
{
    public sealed record Query(string Name) : IRequest<Response>;

    public sealed class Handler(ICityRepository repository)
        : IRequestHandler<Query, Response>
    {
        private const int Limit = 50;

        public async Task<Response> HandleAsync(Query query, CancellationToken cancellationToken)
        {
            IEnumerable<City> cities = await repository
                .GetCitiesByNameAsync(query.Name, Limit, cancellationToken);

            return new Response([.. cities]);
        }
    }

    public sealed record Response(IReadOnlyList<City> Cities);
}
