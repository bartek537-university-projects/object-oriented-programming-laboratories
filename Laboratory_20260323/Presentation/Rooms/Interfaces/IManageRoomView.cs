using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Presentation.Rooms.Interfaces;

public interface IManageRoomView
{
    string Identifier { set; }
    string RoomNumber { get; set; }
    int Capacity { get; set; }
    RoomType RoomType { get; set; }
    Faculty? Faculty { get; set; }

    event EventHandler Load;
    event EventHandler SubmitClicked;
    event EventHandler CancelClicked;

    void SetFaculties(IReadOnlyList<Faculty> faculties);
    void SetErrors(IReadOnlyDictionary<string, string>? errors);
    void Close();
}
