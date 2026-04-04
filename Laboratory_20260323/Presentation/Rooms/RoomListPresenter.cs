using Laboratory_20260323.Application.Rooms;
using Laboratory_20260323.Domain.Entities;
using Laboratory_20260323.Presentation.Rooms.Interfaces;

namespace Laboratory_20260323.Presentation.Rooms;

public class RoomListPresenter : IRoomListPresenter
{
    private readonly IRoomListView _view;
    private readonly IWindowService _windows;

    private readonly IGetRoomsHandler _getRoomsHandler;
    private readonly IDeleteRoomHandler _deleteRoomHandler;

    public RoomListPresenter(IRoomListView view, IWindowService windows,
        IGetRoomsHandler getRoomsHandler, IDeleteRoomHandler deleteRoomHandler)
    {
        _view = view;
        _windows = windows;

        _getRoomsHandler = getRoomsHandler;
        _deleteRoomHandler = deleteRoomHandler;

        _view.AddRoomClicked += OnAddRoomClicked;
        _view.EditRoomClicked += OnEditRoomClicked;
        _view.RemoveRoomClicked += OnRemoveRoomClicked;
    }

    private void OnAddRoomClicked(object? sender, EventArgs e)
    {
        _windows.ShowAddRoomDialog();
        UpdateRoomList();
    }

    private void OnEditRoomClicked(object? sender, Room room)
    {
        _windows.ShowEditRoomDialog(room);
        UpdateRoomList();
    }

    private void OnRemoveRoomClicked(object? sender, Room room)
    {
        _ = _deleteRoomHandler.Handle(new(room.Id));
        UpdateRoomList();
    }

    private void UpdateRoomList()
    {
        IReadOnlyList<Room> rooms = GetAllRooms();
        _view.SetRooms(rooms);
    }

    private IReadOnlyList<Room> GetAllRooms()
    {
        return _getRoomsHandler.Handle(new GetRooms.Query()).Rooms;
    }
}
