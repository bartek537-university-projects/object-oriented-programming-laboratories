using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Presentation;

public interface IWindowService
{
    Form CreateMainWindow();
    void ShowMainWindow();
    UserControl CreateEmployeeListFragment();
    Form CreateAddEmployeeDialog();
    void ShowAddEmployeeDialog();
    Form CreateEditEmployeeDialog(Employee employee);
    void ShowEditEmployeeDialog(Employee employee);
    UserControl CreateFacultyListFragment();
    UserControl CreateRoomListFragment();
}
