using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Application.Faculties.Interfaces;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Faculties;

public class AddFaculty
{
    public record Command(string Name, string City, string PostalCode, string Street, string Building) : IFacultyData;

    public class Handler(IValidator<IFacultyData> validator, IFacultyRepository repository)
        : IAddFacultyHandler
    {
        public Response Handle(Command command)
        {
            ValidateFaculty(command);

            Faculty faculty = CreateFaculty(command);
            repository.Insert(faculty);

            return new Response();
        }

        private void ValidateFaculty(Command command)
        {
            Dictionary<string, string> errors = validator.Validate(command);

            if (errors.Count > 0)
            {
                throw new ValidationException(errors);
            }
        }

        private static Faculty CreateFaculty(Command command)
        {
            return new()
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
        }
    }

    public record Response();
}

public interface IAddFacultyHandler
{
    AddFaculty.Response Handle(AddFaculty.Command command);
}

