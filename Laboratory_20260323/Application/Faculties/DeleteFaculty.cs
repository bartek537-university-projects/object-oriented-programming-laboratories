using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Faculties;

public class DeleteFaculty
{
    public record Command(Guid FacultyId) : IRequest<Response>;

    public class Handler(IFacultyRepository facultyRepository, IRoomRepository roomRepository)
        : IRequestHandler<Command, Response>
    {
        public Response Handle(Command command)
        {
            Faculty faculty = GetFacultyOrThrow(command.FacultyId);

            EnsureHasNoActiveDependencies(faculty);

            facultyRepository.DeleteById(faculty.Id);

            return new Response();
        }

        private Faculty GetFacultyOrThrow(Guid facultyId)
        {
            return facultyRepository.GetById(facultyId) ?? throw new NotFoundException("Faculty does not exist.");
        }

        private void EnsureHasNoActiveDependencies(Faculty faculty)
        {
            if (CheckHasLinkedRooms(faculty))
            {
                throw new ConflictException("Faculty has linked rooms.");
            }
        }

        private bool CheckHasLinkedRooms(Faculty faculty)
        {
            return roomRepository.ExistsByFacultyId(faculty.Id);
        }
    }

    public record Response();
}