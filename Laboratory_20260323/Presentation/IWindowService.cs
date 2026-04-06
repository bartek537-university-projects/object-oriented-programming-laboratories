using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Presentation;

public interface IWindowService
{
    Form CreateMainWindow();
    void ShowMainWindow();
    UserControl CreateEmployeeListFragment();
    Form CreateAddEmployeeDialog();
    Form CreateEditEmployeeDialog(Employee employee);
    void ShowAddEmployeeDialog();
    void ShowEditEmployeeDialog(Employee employee);
    UserControl CreateFacultyListFragment();
    Form CreateAddFacultyDialog();
    Form CreateEditFacultyDialog(Faculty faculty);
    void ShowAddFacultyDialog();
    void ShowEditFacultyDialog(Faculty faculty);
    UserControl CreateRoomListFragment();
    Form CreateAddRoomDialog();
    Form CreateEditRoomDialog(Room room);
    void ShowAddRoomDialog();
    void ShowEditRoomDialog(Room room);
    UserControl CreateReservationListFragment();
    Form CreateAddReservationDialog();
    Form CreateEditReservationDialog(Reservation reservation);
    void ShowAddReservationDialog();
    void ShowEditReservationDialog(Reservation reservation);
}
