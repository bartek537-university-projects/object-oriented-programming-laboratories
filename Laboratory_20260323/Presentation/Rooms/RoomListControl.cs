using Laboratory_20260323.Domain.Entities;
using Laboratory_20260323.Presentation.Rooms.Interfaces;
using System.ComponentModel;

namespace Laboratory_20260323.Presentation.Rooms;

public partial class RoomListControl : UserControl, IRoomListView
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IRoomListPresenter? Presenter { get; set; }

    public event EventHandler AddRoomClicked;
    public event EventHandler<Room> EditRoomClicked;
    public event EventHandler<Room> RemoveRoomClicked;

    public RoomListControl()
    {
        InitializeComponent();

        mlcRooms.AddColumn("Number", nameof(Room.Number));
        mlcRooms.AddColumn("Capacity", nameof(Room.Capacity));
        mlcRooms.AddColumn("Type", nameof(Room.Type));
        mlcRooms.AddColumn("Faculty", nameof(Room.Faculty));

        mlcRooms.AddClicked += OnAddRoomClicked;
        mlcRooms.EditClicked += OnEditRoomClicked;
        mlcRooms.RemoveClicked += OnRemoveRoomClicked;
    }

    private void OnAddRoomClicked(object? sender, EventArgs e)
    {
        AddRoomClicked?.Invoke(this, EventArgs.Empty);
    }

    private void OnEditRoomClicked(object? sender, object item)
    {
        if (item is Room room)
        {
            EditRoomClicked?.Invoke(this, room);
        }
    }

    private void OnRemoveRoomClicked(object? sender, object item)
    {
        if (item is Room room)
        {
            RemoveRoomClicked?.Invoke(this, room);
        }
    }

    public void SetRooms(IReadOnlyList<Room> rooms)
    {
        mlcRooms.DataSource = rooms;
    }

    public void ShowError(string message)
    {
        _ = MessageBox.Show(this, message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
