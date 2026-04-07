using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Rooms;

public class DeleteRoom
{
    public record Command(Guid RoomId) : IRequest<Response>;

    public class Handler(IRoomRepository roomRepository, IReservationRepository reservationRepository)
        : IRequestHandler<Command, Response>
    {
        public Response Handle(Command command)
        {
            Room room = GetRoomOrThrow(command.RoomId);

            EnsureHasNoActiveDependencies(room);

            roomRepository.DeleteById(room.Id);

            return new Response();
        }

        private Room GetRoomOrThrow(Guid roomId)
        {
            return roomRepository.GetById(roomId) ?? throw new NotFoundException("Room does not exist.");
        }

        private void EnsureHasNoActiveDependencies(Room room)
        {
            if (CheckHasLinkedReservations(room))
            {
                throw new ConflictException("Room has linked reservations.");
            }
        }

        private bool CheckHasLinkedReservations(Room room)
        {
            return reservationRepository.ExistsByRoomId(room.Id);
        }
    }

    public record Response();
}
