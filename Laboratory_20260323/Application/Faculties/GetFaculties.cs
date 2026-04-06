using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Faculties;

public class GetFaculties
{
    public record Query() : IRequest<Response>;

    public class Handler(IFacultyRepository repository)
        : IRequestHandler<Query, Response>
    {
        public Response Handle(Query query)
        {
            List<Faculty> faculties = [.. repository.GetAll()];
            return new Response(faculties);
        }
    }

    public record Response(IReadOnlyList<Faculty> Faculties);
}