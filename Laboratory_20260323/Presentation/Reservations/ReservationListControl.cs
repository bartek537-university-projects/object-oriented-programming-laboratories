using Laboratory_20260323.Domain.Entities;
using Laboratory_20260323.Presentation.Reservations.Interfaces;
using System.ComponentModel;

namespace Laboratory_20260323.Presentation.Reservations;

public partial class ReservationListControl : UserControl, IReservationListView
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IReservationListPresenter? Presenter { get; set; }

    public ReservationListControl()
    {
        InitializeComponent();

        mlcReservations.AddColumn("Faculty", nameof(Reservation.Room.Faculty));
        mlcReservations.AddColumn("Room", nameof(Reservation.Room));
        mlcReservations.AddColumn("Time", nameof(Reservation.TimeStart)); // TODO: Create custom column filter.
        mlcReservations.AddColumn("Employee", nameof(Reservation.Employee));
    }
}
