using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Application.Faculties.Interfaces;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Faculties;

public class UpdateFaculty
{
    public record Command(Guid FacultyId, string Name, string City, string PostalCode, string Street, string Building) : IFacultyData;

    public class Handler(IValidator<IFacultyData> validator, IFacultyRepository repository)
        : IUpdateFacultyHandler
    {
        public Response Handle(Command command)
        {
            ValidateFacultyExists(command.FacultyId);
            ValidateFacultyDetails(command);

            Faculty faculty = CreateFaculty(command);
            repository.Update(faculty);

            return new Response();
        }

        private void ValidateFacultyDetails(Command command)
        {
            Dictionary<string, string> errors = validator.Validate(command);

            if (errors.Count > 0)
            {
                throw new ValidationException(errors);
            }
        }

        private void ValidateFacultyExists(Guid facultyId)
        {
            if (repository.GetById(facultyId) is null)
            {
                throw new ArgumentException("Faculty does not exist.", nameof(facultyId));
            }
        }

        private static Faculty CreateFaculty(Command command)
        {
            return new()
            {
                Id = command.FacultyId,
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

public interface IUpdateFacultyHandler
{
    UpdateFaculty.Response Handle(UpdateFaculty.Command command);
}
