using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Presentation.Rooms.Interfaces;

public interface IRoomListView
{
    event EventHandler AddRoomClicked;
    event EventHandler<Room> EditRoomClicked;
    event EventHandler<Room> RemoveRoomClicked;

    void SetRooms(IReadOnlyList<Room> rooms);
}
