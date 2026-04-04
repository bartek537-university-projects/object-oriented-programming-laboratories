using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Application.Faculties;
using Laboratory_20260323.Application.Rooms;
using Laboratory_20260323.Domain.Entities;
using Laboratory_20260323.Presentation.Rooms.Interfaces;

namespace Laboratory_20260323.Presentation.Rooms;

public class AddRoomPresenter : IManageRoomPresenter
{
    private readonly IManageRoomView _view;
    private readonly IAddRoomHandler _addRoomHandler;
    private readonly IGetFacultiesHandler _getFacultiesHandler;

    public AddRoomPresenter(IManageRoomView view, IAddRoomHandler addRoomHandler, IGetFacultiesHandler getFacultiesHandler)
    {
        _view = view;
        _addRoomHandler = addRoomHandler;
        _getFacultiesHandler = getFacultiesHandler;

        _view.Load += OnViewLoaded;
        _view.SubmitClicked += OnSubmitClicked;
        _view.CancelClicked += OnCancelClicked;
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
        Faculty? faculty = _view.Faculty;

        if (faculty is null)
        {
            _view.SetErrors(new Dictionary<string, string>
            {
                [nameof(Room.Faculty)] = "Create a faculty first."
            });
            return;
        }

        AddRoom.Command command = new(roomNumber, capacity, roomType, faculty.Id);

        try
        {
            AddRoom.Response _ = _addRoomHandler.Handle(command);
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
