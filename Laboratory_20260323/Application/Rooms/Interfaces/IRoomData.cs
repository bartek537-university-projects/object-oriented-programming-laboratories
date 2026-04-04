using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Rooms.Interfaces;

public interface IRoomData
{
    string Number { get; }
    int Capacity { get; }
    RoomType Type { get; }
}
