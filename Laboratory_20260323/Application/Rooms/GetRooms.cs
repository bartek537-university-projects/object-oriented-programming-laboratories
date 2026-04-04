using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Rooms;

public class GetRooms
{
    public record Query();

    public class Handler(IRoomRepository repository)
        : IGetRoomsHandler
    {
        public Response Handle(Query query)
        {
            List<Room> rooms = repository.GetAll().ToList();
            return new Response(rooms);
        }
    }

    public record Response(IReadOnlyList<Room> Rooms);
}

public interface IGetRoomsHandler
{
    GetRooms.Response Handle(GetRooms.Query query);
}
