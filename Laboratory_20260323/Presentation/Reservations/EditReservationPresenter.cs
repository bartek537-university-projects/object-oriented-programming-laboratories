using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Application.Employees;
using Laboratory_20260323.Application.Reservations;
using Laboratory_20260323.Application.Rooms;
using Laboratory_20260323.Domain.Entities;
using Laboratory_20260323.Presentation.Reservations.Interfaces;

namespace Laboratory_20260323.Presentation.Reservations;

public class EditReservationPresenter : IManageReservationPresenter
{
    private readonly IManageReservationView _view;

    private readonly IRequestHandler<UpdateReservation.Command, UpdateReservation.Response> _updateReservationHandler;
    private readonly IGetRoomsHandler _getRoomsHandler;
    private readonly IGetEmployeesHandler _getEmployeesHandler;

    private readonly Reservation _reservation;

    public EditReservationPresenter(Reservation reservation, IManageReservationView view,
        IRequestHandler<UpdateReservation.Command, UpdateReservation.Response> updateReservationHandler,
        IGetRoomsHandler getRoomsHandler, IGetEmployeesHandler getEmployeesHandler)
    {
        _reservation = reservation;

        _view = view;

        _updateReservationHandler = updateReservationHandler;
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
        LoadReservationIntoView();
    }

    private void LoadReservationIntoView()
    {
        _view.Identifier = _reservation.Id.ToString();
        _view.Room = _reservation.Room;
        _view.Employee = _reservation.Employee;
        _view.TimeStart = _reservation.Start;
        _view.TimeEnd = _reservation.End;
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

        UpdateReservation.Command command = new(_reservation.Id, room?.Id, employee?.Id, start, end);

        try
        {
            _ = _updateReservationHandler.Handle(command);
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
