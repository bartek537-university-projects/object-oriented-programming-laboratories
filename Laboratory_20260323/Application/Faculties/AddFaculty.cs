using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Faculties;

public class AddFaculty
{
    public record Command(string Name, string City, string PostalCode, string Street, string Building) : IRequest<Response>;

    public class Handler(IValidator<Command> validator, IFacultyRepository repository)
        : IRequestHandler<Command, Response>
    {
        public Response Handle(Command command)
        {
            ValidateRequest(command);

            Faculty faculty = new()
            {
                Name = command.Name,
                Address = new()
                {
                    City = command.City,
                    PostalCode = command.PostalCode,
                    Street = command.Street,
                    Building = command.Building
                }
            };

            repository.Insert(faculty);

            return new Response();
        }

        private void ValidateRequest(Command command)
        {
            if (validator.Validate(command) is { Count: > 0 } errors)
            {
                throw new ValidationException(errors);
            }
        }
    }

    public record Response();
}
