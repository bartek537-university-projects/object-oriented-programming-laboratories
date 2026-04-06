using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Application.Employees;
using Laboratory_20260323.Application.Reservations;
using Laboratory_20260323.Application.Rooms;
using Laboratory_20260323.Domain.Entities;
using Laboratory_20260323.Presentation.Reservations.Interfaces;

namespace Laboratory_20260323.Presentation.Reservations;

public class AddReservationPresenter : IManageReservationPresenter
{
    private readonly IManageReservationView _view;

    private readonly IRequestHandler<AddReservation.Command, AddReservation.Response> _addReservationHandler;
    private readonly IRequestHandler<GetRooms.Query, GetRooms.Response> _getRoomsHandler;
    private readonly IRequestHandler<GetEmployees.Query, GetEmployees.Response> _getEmployeesHandler;

    public AddReservationPresenter(IManageReservationView view,
        IRequestHandler<AddReservation.Command, AddReservation.Response> addReservationHandler,
        IRequestHandler<GetRooms.Query, GetRooms.Response> getRoomsHandler,
        IRequestHandler<GetEmployees.Query, GetEmployees.Response> getEmployeesHandler)
    {
        _view = view;

        _addReservationHandler = addReservationHandler;
        _getRoomsHandler = getRoomsHandler;
        _getEmployeesHandler = getEmployeesHandler;

        _view.Load += OnViewLoaded;
        _view.SubmitClicked += OnSubmitClicked;
        _view.CancelClicked += OnCancelClicked;
    }

    private void OnViewLoaded(object? sender, EventArgs e)
    {
        _view.SetRooms(GetAllRooms());
        _view.SetEmployees(GetAllEmployees());
    }

    private IReadOnlyList<Room> GetAllRooms()
    {
        return _getRoomsHandler.Handle(new()).Rooms;
    }

    private IReadOnlyList<Employee> GetAllEmployees()
    {
        return _getEmployeesHandler.Handle(new()).Employees;
    }

    private void OnSubmitClicked(object? sender, EventArgs e)
    {
        _view.SetErrors(null);

        Room? room = _view.Room;
        Employee? employee = _view.Employee;
        DateTime start = _view.TimeStart;
        DateTime end = _view.TimeEnd;

        AddReservation.Command command = new(room?.Id, employee?.Id, start, end);

        try
        {
            _ = _addReservationHandler.Handle(command);
            _view.Close();
        }
        catch (ValidationException ex)
        {
            _view.SetErrors(ex.Errors);
        }
        catch (ConflictException ex)
        {
            _view.SetErrors(GetConflictErrors(ex));
        }
    }

    private static Dictionary<string, string> GetConflictErrors(ConflictException ex)
    {
        Dictionary<string, string> errors = [];

        if (ex.Field is string field)
        {
            errors[field] = ex.Message;
        }

        return errors;
    }

    private void OnCancelClicked(object? sender, EventArgs e)
    {
        _view.Close();
    }
}
