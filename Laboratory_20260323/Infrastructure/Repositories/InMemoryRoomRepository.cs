using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Infrastructure.Repositories;

internal class InMemoryRoomRepository : IRoomRepository
{
    private Dictionary<Guid, Room> _rooms = [];

    public void ReplaceAll(IReadOnlyList<Room> rooms)
    {
        _rooms = rooms.ToDictionary(room => room.Id);
    }

    public void Insert(Room room)
    {
        if (_rooms.ContainsKey(room.Id))
        {
            throw new ArgumentException("Room already exists.", nameof(room));
        }
        _rooms[room.Id] = room;
    }

    public IEnumerable<Room> GetAll()
    {
        return _rooms.Values;
    }

    public Room? GetById(Guid roomId)
    {
        _ = _rooms.TryGetValue(roomId, out Room? room);
        return room;
    }

    public bool ExistsById(Guid roomId)
    {
        return _rooms.ContainsKey(roomId);
    }

    public bool ExistsByFacultyId(Guid facultyId)
    {
        return _rooms.Values.Any(room => room.Faculty.Id == facultyId);
    }

    public void Update(Room room)
    {
        if (!_rooms.ContainsKey(room.Id))
        {
            throw new ArgumentException("Room does not exist.", nameof(room));
        }
        _rooms[room.Id] = room;
    }

    public void DeleteById(Guid roomId)
    {
        _ = _rooms.Remove(roomId);
    }
}
