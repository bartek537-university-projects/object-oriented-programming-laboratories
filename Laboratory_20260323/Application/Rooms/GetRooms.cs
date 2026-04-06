using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Rooms;

public class GetRooms
{
    public record Query() : IRequest<Response>;

    public class Handler(IRoomRepository repository)
        : IRequestHandler<Query, Response>
    {
        public Response Handle(Query query)
        {
            List<Room> rooms = [.. repository.GetAll()];
            return new Response(rooms);
        }
    }

    public record Response(IReadOnlyList<Room> Rooms);
}