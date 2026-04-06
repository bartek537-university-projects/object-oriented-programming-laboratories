using Laboratory_20260323.Domain.Entities;
using Laboratory_20260323.Presentation.Reservations.Interfaces;
using System.ComponentModel;

namespace Laboratory_20260323.Presentation.Reservations;

public partial class ReservationListControl : UserControl, IReservationListView
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IReservationListPresenter? Presenter { get; set; }

    public event EventHandler? AddReservationClicked;
    public event EventHandler<Reservation>? EditReservationClicked;
    public event EventHandler<Reservation>? RemoveReservationClicked;

    public ReservationListControl()
    {
        InitializeComponent();

        mlcReservations.AddColumn("Faculty", nameof(Reservation.Room.Faculty));
        mlcReservations.AddColumn("Room", nameof(Reservation.Room));
        mlcReservations.AddColumn("Start", nameof(Reservation.Start));
        mlcReservations.AddColumn("End", nameof(Reservation.End));
        mlcReservations.AddColumn("Employee", nameof(Reservation.Employee));

        mlcReservations.AddClicked += OnAddReservationClicked;
        mlcReservations.EditClicked += OnEditReservationClicked;
        mlcReservations.RemoveClicked += OnRemoveReservationClicked;
    }

    private void OnAddReservationClicked(object? sender, EventArgs e)
    {
        AddReservationClicked?.Invoke(this, EventArgs.Empty);
    }

    private void OnEditReservationClicked(object? sender, object item)
    {
        if (item is Reservation reservation)
        {
            RemoveReservationClicked?.Invoke(this, reservation);
        }
    }

    private void OnRemoveReservationClicked(object? sender, object item)
    {
        if (item is Reservation reservation)
        {
            RemoveReservationClicked?.Invoke(this, reservation);
        }
    }

    public void SetReservations(IReadOnlyList<Reservation> reservations)
    {
        mlcReservations.DataSource = reservations;
    }
}
