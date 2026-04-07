using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Application.Persistence.Mappers;

namespace Laboratory_20260323.Application.Persistence;

public class SaveToFile
{
    public record Command(string Path) : IRequest<Response>;

    public class Handler(IApplicationDataMapper mapper, IApplicationSnapshotRepository snapshotRepository,
        IEmployeeRepository employeeRepository, IFacultyRepository facultyRepository,
        IRoomRepository roomRepository, IReservationRepository reservationRepository)
        : IRequestHandler<Command, Response>
    {
        public Response Handle(Command request)
        {
            ApplicationDataState state = GetApplicationDataState();
            ApplicationDataSnapshot snapshot = mapper.ToSnapshot(state);

            SaveSnapshotToFile(snapshot, request.Path);

            return new Response();
        }

        private ApplicationDataState GetApplicationDataState()
        {
            return new()
            {
                Employees = [.. employeeRepository.GetAll()],
                Faculties = [.. facultyRepository.GetAll()],
                Rooms = [.. roomRepository.GetAll()],
                Reservations = [.. reservationRepository.GetAll()]
            };
        }

        private void SaveSnapshotToFile(ApplicationDataSnapshot snapshot, string path)
        {
            snapshotRepository.Save(snapshot, path);
        }
    }

    public record Response();
}
