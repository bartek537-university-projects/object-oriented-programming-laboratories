using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Reservations;
using Laboratory_20260323.Domain.Entities;
using Laboratory_20260323.Presentation.Reservations.Interfaces;

namespace Laboratory_20260323.Presentation.Reservations;

public class ReservationListPresenter : IReservationListPresenter
{
    private readonly IReservationListView _view;
    private readonly IWindowService _windows;

    private readonly IRequestHandler<GetReservations.Query, GetReservations.Response> _getReservationsHandler;
    private readonly IRequestHandler<DeleteReservation.Command, DeleteReservation.Response> _deleteReservationHandler;

    public ReservationListPresenter(IReservationListView view, IWindowService windows,
        IRequestHandler<GetReservations.Query, GetReservations.Response> getReservationsHandler,
        IRequestHandler<DeleteReservation.Command, DeleteReservation.Response> deleteReservationHandler)
    {
        _view = view;
        _windows = windows;

        _getReservationsHandler = getReservationsHandler;
        _deleteReservationHandler = deleteReservationHandler;

        _view.AddReservationClicked += OnAddReservationClicked;
        _view.EditReservationClicked += OnEditReservationClicked;
        _view.RemoveReservationClicked += OnRemoveReservationClicked;
    }

    private void OnAddReservationClicked(object? sender, EventArgs e)
    {
        _windows.ShowAddReservationDialog();
        UpdateReservationList();
    }

    private void OnEditReservationClicked(object? sender, Reservation reservation)
    {
        _windows.ShowEditReservationDialog(reservation);
        UpdateReservationList();
    }

    private void OnRemoveReservationClicked(object? sender, Reservation reservation)
    {
        _ = _deleteReservationHandler.Handle(new(reservation.Id));
        UpdateReservationList();
    }

    private void UpdateReservationList()
    {
        IReadOnlyList<Reservation> reservations = GetAllReservations();
        _view.SetReservations(reservations);
    }

    private IReadOnlyList<Reservation> GetAllReservations()
    {
        return _getReservationsHandler.Handle(new()).Reservations;
    }
}
