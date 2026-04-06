using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Faculties;

public class DeleteFaculty
{
    public record Command(Guid FacultyId) : IRequest<Response>;

    public class Handler(IFacultyRepository repository)
        : IRequestHandler<Command, Response>
    {
        public Response Handle(Command command)
        {
            Faculty faculty = GetFacultyOrThrow(command.FacultyId);
            // TODO: Add check for related data (rooms).

            repository.DeleteById(faculty.Id);

            return new Response();
        }

        private Faculty GetFacultyOrThrow(Guid facultyId)
        {
            return repository.GetById(facultyId) ?? throw new NotFoundException("Faculty does not exist.");
        }
    }

    public record Response();
}