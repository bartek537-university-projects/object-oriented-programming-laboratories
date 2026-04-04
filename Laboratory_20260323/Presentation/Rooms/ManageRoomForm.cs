using Laboratory_20260323.Domain.Entities;
using Laboratory_20260323.Presentation.Rooms.Interfaces;
using System.ComponentModel;

namespace Laboratory_20260323.Presentation.Rooms;

public partial class ManageRoomForm : Form, IManageRoomView
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IManageRoomPresenter? Presenter { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Identifier { set => tbIdentifier.Text = value; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string RoomNumber { get => tbRoomNumber.Text; set => tbRoomNumber.Text = value; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int Capacity { get => (int)nudCapacity.Value; set => nudCapacity.Value = value; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public RoomType RoomType { get => (RoomType)cbType.SelectedValue!; set => cbType.SelectedValue = value; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Faculty? Faculty { get => cbFaculty.SelectedValue as Faculty; set => cbFaculty.SelectedValue = value; }

    public event EventHandler? SubmitClicked;
    public event EventHandler? CancelClicked;

    public ManageRoomForm()
    {
        InitializeComponent();

        cbType.DataSource = GetAvailableRoomTypes();
        cbType.ValueMember = nameof(KeyValuePair<,>.Key);
        cbType.DisplayMember = nameof(KeyValuePair<,>.Value);

        cbFaculty.DisplayMember = nameof(Faculty.Name);
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

    public void SetFaculties(IReadOnlyList<Faculty> faculties)
    {
        cbFaculty.DataSource = faculties;
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
            nameof(Room.Number) => tbRoomNumber,
            nameof(Room.Capacity) => nudCapacity,
            nameof(Room.Faculty) => cbFaculty,
            _ => null
        };
    }

    private static IReadOnlyList<KeyValuePair<RoomType, string>> GetAvailableRoomTypes()
    {
        return [
            KeyValuePair.Create(RoomType.Lecture, "Lecture hall"),
            KeyValuePair.Create(RoomType.Tutorial, "Tutorial room"),
            KeyValuePair.Create(RoomType.Computer, "Computer lab"),
        ];
    }
}
