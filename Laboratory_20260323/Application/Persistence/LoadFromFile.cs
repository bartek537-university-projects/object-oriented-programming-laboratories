using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Application.Persistence.Mappers;

namespace Laboratory_20260323.Application.Persistence;

public class LoadFromFile
{
    public record Command(string Path) : IRequest<Response>;

    public class Handler(IApplicationDataMapper mapper, IApplicationSnapshotRepository snapshotRepository,
        IEmployeeRepository employeeRepository, IFacultyRepository facultyRepository,
        IRoomRepository roomRepository, IReservationRepository reservationRepository)
        : IRequestHandler<Command, Response>
    {
        public Response Handle(Command request)
        {
            ApplicationDataSnapshot snapshot = LoadSnapshotFromFile(request.Path);
            ApplicationDataState state = mapper.ToDomain(snapshot);

            ReplaceAppState(state);

            return new Response();
        }

        private ApplicationDataSnapshot LoadSnapshotFromFile(string path)
        {
            return snapshotRepository.Load(path);
        }

        private void ReplaceAppState(ApplicationDataState state)
        {
            employeeRepository.ReplaceAll(state.Employees);
            facultyRepository.ReplaceAll(state.Faculties);
            roomRepository.ReplaceAll(state.Rooms);
            reservationRepository.ReplaceAll(state.Reservations);
        }
    }

    public record Response();
}
