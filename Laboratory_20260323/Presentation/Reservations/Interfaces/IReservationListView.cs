using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Presentation.Reservations.Interfaces;

public interface IReservationListView
{
    event EventHandler AddReservationClicked;
    event EventHandler<Reservation> EditReservationClicked;
    event EventHandler<Reservation> RemoveReservationClicked;

    void SetReservations(IReadOnlyList<Reservation> reservations);
}
