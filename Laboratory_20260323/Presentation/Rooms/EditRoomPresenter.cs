using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Application.Faculties;
using Laboratory_20260323.Application.Rooms;
using Laboratory_20260323.Domain.Entities;
using Laboratory_20260323.Presentation.Rooms.Interfaces;

namespace Laboratory_20260323.Presentation.Rooms;

public class EditRoomPresenter : IManageRoomPresenter
{
    private readonly IManageRoomView _view;
    private readonly IUpdateRoomHandler _updateRoomHandler;
    private readonly IGetFacultiesHandler _getFacultiesHandler;

    private readonly Room _room;

    public EditRoomPresenter(Room room, IManageRoomView view, IUpdateRoomHandler updateRoomHandler, IGetFacultiesHandler getFacultiesHandler)
    {
        _room = room;

        _view = view;
        _updateRoomHandler = updateRoomHandler;
        _getFacultiesHandler = getFacultiesHandler;

        LoadRoomIntoView();

        _view.Load += OnViewLoaded;
        _view.SubmitClicked += OnSubmitClicked;
        _view.CancelClicked += OnCancelClicked;
    }

    private void LoadRoomIntoView()
    {
        _view.Identifier = _room.Id.ToString();
        _view.RoomNumber = _room.Number;
        _view.RoomType = _room.Type;
        _view.Faculty = _room.Faculty;
    }

    private void OnViewLoaded(object? sender, EventArgs e)
    {
        var faculties = _getFacultiesHandler.Handle(new()).Faculties;
        _view.SetFaculties(faculties);
    }

    private void OnSubmitClicked(object? sender, EventArgs e)
    {
        _view.SetErrors(null);

        string roomNumber = _view.RoomNumber;
        int capacity = _view.Capacity;
        RoomType roomType = _view.RoomType;
        Faculty faculty = _view.Faculty!;

        UpdateRoom.Command command = new(_room.Id, roomNumber, capacity, roomType, faculty.Id);

        try
        {
            UpdateRoom.Response _ = _updateRoomHandler.Handle(command);
            _view.Close();
        }
        catch (ValidationException ex)
        {
            _view.SetErrors(ex.Errors);
        }
    }

    private void OnCancelClicked(object? sender, EventArgs e)
    {
        _view.Close();
    }
}
