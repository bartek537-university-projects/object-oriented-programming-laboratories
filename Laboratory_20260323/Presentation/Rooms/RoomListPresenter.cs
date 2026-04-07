using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Application.Rooms;
using Laboratory_20260323.Domain.Entities;
using Laboratory_20260323.Presentation.Rooms.Interfaces;

namespace Laboratory_20260323.Presentation.Rooms;

public class RoomListPresenter : IRoomListPresenter
{
    private readonly IRoomListView _view;
    private readonly IWindowService _windows;

    private readonly IRequestHandler<GetRooms.Query, GetRooms.Response> _getRoomsHandler;
    private readonly IRequestHandler<DeleteRoom.Command, DeleteRoom.Response> _deleteRoomHandler;

    public RoomListPresenter(IRoomListView view, IWindowService windows,
        IRequestHandler<GetRooms.Query, GetRooms.Response> getRoomsHandler,
        IRequestHandler<DeleteRoom.Command, DeleteRoom.Response> deleteRoomHandler)
    {
        _view = view;
        _windows = windows;

        _getRoomsHandler = getRoomsHandler;
        _deleteRoomHandler = deleteRoomHandler;

        _view.AddRoomClicked += OnAddRoomClicked;
        _view.EditRoomClicked += OnEditRoomClicked;
        _view.RemoveRoomClicked += OnRemoveRoomClicked;

        UpdateRoomList();
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
        try
        {
            _ = _deleteRoomHandler.Handle(new(room.Id));
            UpdateRoomList();
        }
        catch (ConflictException ex)
        {
            _view.ShowError(ex.Message);
        }
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
