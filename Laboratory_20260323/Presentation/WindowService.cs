using Laboratory_20260323.Application.Employees;
using Laboratory_20260323.Application.Faculties;
using Laboratory_20260323.Application.Rooms;
using Laboratory_20260323.Domain.Entities;
using Laboratory_20260323.Presentation.Employees;
using Laboratory_20260323.Presentation.Faculties;
using Laboratory_20260323.Presentation.Main;
using Laboratory_20260323.Presentation.Reservations;
using Laboratory_20260323.Presentation.Rooms;

namespace Laboratory_20260323.Presentation;

public class WindowService(
    IAddEmployeeHandler addEmployeeHandler,
    IGetEmployeesHandler getEmployeesHandler,
    IUpdateEmployeeHandler updateEmployeeHandler,
    IDeleteEmployeeHandler deleteEmployeeHandler,
    IAddFacultyHandler addFacultyHandler,
    IGetFacultiesHandler getFacultiesHandler,
    IUpdateFacultyHandler updateFacultyHandler,
    IDeleteFacultyHandler deleteFacultyHandler,
    IAddRoomHandler addRoomHandler,
    IGetRoomsHandler getRoomsHandler,
    IUpdateRoomHandler updateRoomHandler,
    IDeleteRoomHandler deleteRoomHandler
) : IWindowService
{
    public Form CreateMainWindow()
    {
        MainForm form = new();
        MainPresenter presenter = new(form, this);
        form.Presenter = presenter;

        return form;
    }

    public void ShowMainWindow()
    {
        CreateMainWindow().Show();
    }

    public UserControl CreateEmployeeListFragment()
    {
        EmployeeListControl control = new();
        EmployeeListPresenter presenter = new(control, this,
            getEmployeesHandler, deleteEmployeeHandler);
        control.Presenter = presenter;

        return control;
    }

    public Form CreateAddEmployeeDialog()
    {
        ManageEmployeeForm form = new();
        AddEmployeePresenter presenter = new(form, addEmployeeHandler);
        form.Presenter = presenter;

        return form;
    }

    public void ShowAddEmployeeDialog()
    {
        _ = CreateAddEmployeeDialog().ShowDialog();
    }

    public Form CreateEditEmployeeDialog(Employee employee)
    {
        ManageEmployeeForm form = new();
        EditEmployeePresenter presenter = new(employee, form, updateEmployeeHandler);
        form.Presenter = presenter;

        return form;
    }

    public void ShowEditEmployeeDialog(Employee employee)
    {
        _ = CreateEditEmployeeDialog(employee).ShowDialog();
    }

    public UserControl CreateFacultyListFragment()
    {
        FacultyListControl control = new();
        FacultyListPresenter presenter = new(control, this,
            getFacultiesHandler, deleteFacultyHandler);
        control.Presenter = presenter;

        return control;
    }

    public Form CreateAddFacultyDialog()
    {
        ManageFacultyForm form = new();
        AddFacultyPresenter presenter = new(form, addFacultyHandler);
        form.Presenter = presenter;

        return form;
    }

    public void ShowAddFacultyDialog()
    {
        _ = CreateAddFacultyDialog().ShowDialog();
    }

    public Form CreateEditFacultyDialog(Faculty faculty)
    {
        ManageFacultyForm form = new();
        EditFacultyPresenter presenter = new(faculty, form, updateFacultyHandler);
        form.Presenter = presenter;

        return form;
    }

    public void ShowEditFacultyDialog(Faculty faculty)
    {
        _ = CreateEditFacultyDialog(faculty).ShowDialog();
    }

    public UserControl CreateRoomListFragment()
    {
        RoomListControl control = new();
        RoomListPresenter presenter = new(control, this,
            getRoomsHandler, deleteRoomHandler);
        control.Presenter = presenter;

        return control;
    }

    public Form CreateAddRoomDialog()
    {
        throw new NotImplementedException();
    }

    public void ShowAddRoomDialog()
    {
        CreateAddRoomDialog().ShowDialog();
    }

    public Form CreateEditRoomDialog(Room room)
    {
        throw new NotImplementedException();
    }

    public void ShowEditRoomDialog(Room room)
    {
        CreateEditRoomDialog(room).ShowDialog();
    }

    public UserControl CreateReservationListFragment()
    {
        ReservationListControl control = new();
        ReservationListPresenter presenter = new(control);
        control.Presenter = presenter;

        return control;
    }
}
