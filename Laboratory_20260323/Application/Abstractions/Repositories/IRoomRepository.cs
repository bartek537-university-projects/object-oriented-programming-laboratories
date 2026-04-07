using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Abstractions.Repositories;

public interface IRoomRepository
{
    void ReplaceAll(IReadOnlyList<Room> rooms);

    void Insert(Room room);

    IEnumerable<Room> GetAll();
    Room? GetById(Guid roomId);

    bool ExistsById(Guid roomId);

    void Update(Room room);

    void DeleteById(Guid roomId);
}
