using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Presentation.Reservations.Interfaces;

public interface IManageReservationView
{
    string Identifier { set; }
    Room? Room { get; set; }
    Employee? Employee { get; set; }
    DateTime TimeStart { get; set; }
    DateTime TimeEnd { get; set; }

    event EventHandler Load;
    event EventHandler SubmitClicked;
    event EventHandler CancelClicked;

    void SetRooms(IReadOnlyList<Room> rooms);
    void SetEmployees(IReadOnlyList<Employee> employees);
    void SetErrors(IReadOnlyDictionary<string, string>? errors);
    void Close();
}
