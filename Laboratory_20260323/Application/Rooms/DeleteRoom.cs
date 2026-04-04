using Laboratory_20260323.Application.Abstractions.Repositories;

namespace Laboratory_20260323.Application.Rooms;

public class DeleteRoom
{
    public record Command(Guid RoomId);

    public class Handler(IRoomRepository repository)
        : IDeleteRoomHandler
    {
        public Response Handle(Command command)
        {
            ValidateRoomExists(command.RoomId);
            //ValidateNoReservationsExist(command.roomId);
            // TODO: Add check for related data (reservations).

            repository.DeleteById(command.RoomId);

            return new Response();
        }

        private void ValidateRoomExists(Guid roomId)
        {
            if (!repository.ExistsById(roomId))
            {
                throw new ArgumentException("Room does not exist.", nameof(roomId));
            }
        }
    }

    public record Response();
}

public interface IDeleteRoomHandler
{
    DeleteRoom.Response Handle(DeleteRoom.Command command);
}
