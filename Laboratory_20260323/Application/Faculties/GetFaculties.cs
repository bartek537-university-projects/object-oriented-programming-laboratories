using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Faculties;

public class GetFaculties
{
    public record Query();

    public class Handler(IFacultyRepository repository)
        : IGetFacultiesHandler
    {
        public Response Handle(Query query)
        {
            List<Faculty> faculties = repository.GetAll().ToList();
            return new Response(faculties);
        }
    }

    public record Response(IReadOnlyList<Faculty> Faculties);
}

public interface IGetFacultiesHandler
{
    GetFaculties.Response Handle(GetFaculties.Query query);
}