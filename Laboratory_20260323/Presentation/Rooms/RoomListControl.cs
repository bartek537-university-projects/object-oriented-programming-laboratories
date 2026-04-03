using Laboratory_20260323.Domain.Entities;
using Laboratory_20260323.Presentation.Rooms.Interfaces;
using System.ComponentModel;

namespace Laboratory_20260323.Presentation.Rooms;

public partial class RoomListControl : UserControl, IRoomListView
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IRoomListPresenter? Presenter { get; set; }

    public RoomListControl()
    {
        InitializeComponent();

        mlcRooms.AddColumn("Number", nameof(Room.Number));
        mlcRooms.AddColumn("Capacity", nameof(Room.Capacity));
        mlcRooms.AddColumn("Type", nameof(Room.Type));
        mlcRooms.AddColumn("Faculty", nameof(Room.Faculty));
    }
}
