using Laboratory_20260323.Application.Abstractions.Repositories;

namespace Laboratory_20260323.Application.Faculties;

public class DeleteFaculty
{
    public record Command(Guid FacultyId);

    public class Handler(IFacultyRepository repository)
        : IDeleteFacultyHandler
    {
        public Response Handle(Command command)
        {
            ValidateFacultyExists(command.FacultyId);
            //ValidateNoRoomsExist(command.FacultyId);
            // TODO: Add check for related data (rooms).

            repository.DeleteById(command.FacultyId);

            return new Response();
        }

        private void ValidateFacultyExists(Guid facultyId)
        {
            if (!repository.ExistsById(facultyId))
            {
                throw new ArgumentException("Faculty does not exist.", nameof(facultyId));
            }
        }
    }

    public record Response();
}

public interface IDeleteFacultyHandler
{
    DeleteFaculty.Response Handle(DeleteFaculty.Command command);
}