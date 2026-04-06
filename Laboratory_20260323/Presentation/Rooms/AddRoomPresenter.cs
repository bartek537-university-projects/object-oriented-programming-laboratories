using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Application.Faculties;
using Laboratory_20260323.Application.Rooms;
using Laboratory_20260323.Domain.Entities;
using Laboratory_20260323.Presentation.Rooms.Interfaces;

namespace Laboratory_20260323.Presentation.Rooms;

public class AddRoomPresenter : IManageRoomPresenter
{
    private readonly IManageRoomView _view;

    private readonly IRequestHandler<AddRoom.Command, AddRoom.Response> _addRoomHandler;
    private readonly IRequestHandler<GetFaculties.Query, GetFaculties.Response> _getFacultiesHandler;

    public AddRoomPresenter(IManageRoomView view,
        IRequestHandler<AddRoom.Command, AddRoom.Response> addRoomHandler,
        IRequestHandler<GetFaculties.Query, GetFaculties.Response> getFacultiesHandler)
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
        _view.SetFaculties(GetAllFaculties());
    }

    private IReadOnlyList<Faculty> GetAllFaculties()
    {
        return _getFacultiesHandler.Handle(new()).Faculties;
    }

    private void OnSubmitClicked(object? sender, EventArgs e)
    {
        _view.SetErrors(null);

        string roomNumber = _view.RoomNumber;
        int capacity = _view.Capacity;
        RoomType roomType = _view.RoomType;
        Faculty? faculty = _view.Faculty;

        AddRoom.Command command = new(roomNumber, capacity, roomType, faculty?.Id);

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
