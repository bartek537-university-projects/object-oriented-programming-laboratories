using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Rooms;

public class DeleteRoom
{
    public record Command(Guid RoomId) : IRequest<Response>;

    public class Handler(IRoomRepository repository)
        : IRequestHandler<Command, Response>
    {
        public Response Handle(Command command)
        {
            Room room = GetRoomOrThrow(command.RoomId);
            // TODO: Add check for related data (reservations).

            repository.DeleteById(room.Id);

            return new Response();
        }

        private Room GetRoomOrThrow(Guid roomId)
        {
            return repository.GetById(roomId) ?? throw new NotFoundException("Room does not exist.");
        }
    }

    public record Response();
}
