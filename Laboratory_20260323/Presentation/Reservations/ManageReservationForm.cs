using Laboratory_20260323.Domain.Entities;
using Laboratory_20260323.Presentation.Reservations.Interfaces;
using System.ComponentModel;

namespace Laboratory_20260323.Presentation.Reservations;

public partial class ManageReservationForm : Form, IManageReservationView
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IManageReservationPresenter? Presenter { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Identifier { set => tbIdentifier.Text = value; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Room? Room { get => cbRoom.SelectedItem as Room; set => cbRoom.SelectedItem = value; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Employee? Employee { get => cbEmployee.SelectedItem as Employee; set => cbEmployee.SelectedItem = value; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DateTime TimeStart { get => dtpStartTime.Value; set => dtpStartTime.Value = value; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DateTime TimeEnd { get => dtpEndTime.Value; set => dtpEndTime.Value = value; }

    public event EventHandler? SubmitClicked;
    public event EventHandler? CancelClicked;

    public ManageReservationForm()
    {
        InitializeComponent();
        OnTimeChanged();

        cbRoom.DisplayMember = nameof(Room.Number);
    }

    private void dtpStartTime_ValueChanged(object sender, EventArgs e)
    {
        OnTimeChanged();
    }

    private void dtpEndTime_ValueChanged(object sender, EventArgs e)
    {
        OnTimeChanged();
    }

    private void OnTimeChanged()
    {
        TimeSpan duration = TimeEnd - TimeStart;
        DisplayDuration(duration);
    }

    private void DisplayDuration(TimeSpan duration)
    {
        bool isNegative = duration < TimeSpan.Zero;
        string sign = "+";

        if (isNegative)
        {
            duration *= -1;
            sign = "-";
        }

        double hours = Math.Floor(duration.TotalHours);
        int minutes = duration.Minutes;

        lbDuration.Text = $"{sign} {hours}h {minutes}min";
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        OnSubmitClicked();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        OnCancelClicked();
    }

    private void OnSubmitClicked()
    {
        SubmitClicked?.Invoke(this, EventArgs.Empty);
    }

    private void OnCancelClicked()
    {
        CancelClicked?.Invoke(this, EventArgs.Empty);
    }

    public void SetRooms(IReadOnlyList<Room> rooms)
    {
        cbRoom.DataSource = rooms;
    }

    public void SetEmployees(IReadOnlyList<Employee> employees)
    {
        cbEmployee.DataSource = employees;
    }

    public void SetErrors(IReadOnlyDictionary<string, string>? errors)
    {
        errorProvider.Clear();

        if (errors is null)
        {
            return;
        }

        foreach ((string key, string message) in errors)
        {
            SetError(key, message);
        }
    }

    private void SetError(string key, string message)
    {
        if (FindControl(key) is not { } control)
        {
            return;
        }
        errorProvider.SetError(control, message);
    }

    private Control? FindControl(string key)
    {
        return key switch
        {
            nameof(Reservation.Room) => cbRoom,
            nameof(Reservation.Employee) => cbEmployee,
            nameof(Reservation.Start) => dtpStartTime,
            nameof(Reservation.End) => dtpEndTime,
            _ => null
        };
    }
}
