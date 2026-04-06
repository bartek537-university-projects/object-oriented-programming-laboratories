using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Employees;
using Laboratory_20260323.Application.Faculties;
using Laboratory_20260323.Application.Reservations;
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
    IDeleteRoomHandler deleteRoomHandler,
    IRequestHandler<AddReservation.Command, AddReservation.Response> addReservationHandler,
    IRequestHandler<GetReservations.Query, GetReservations.Response> getReservationsHandler,
    IRequestHandler<UpdateReservation.Command, UpdateReservation.Response> updateReservationHandler,
    IRequestHandler<DeleteReservation.Command, DeleteReservation.Response> deleteReservationHandler
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

    public Form CreateEditEmployeeDialog(Employee employee)
    {
        ManageEmployeeForm form = new();
        EditEmployeePresenter presenter = new(employee, form, updateEmployeeHandler);
        form.Presenter = presenter;

        return form;
    }

    public void ShowAddEmployeeDialog()
    {
        _ = CreateAddEmployeeDialog().ShowDialog();
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

    public Form CreateEditFacultyDialog(Faculty faculty)
    {
        ManageFacultyForm form = new();
        EditFacultyPresenter presenter = new(faculty, form, updateFacultyHandler);
        form.Presenter = presenter;

        return form;
    }

    public void ShowAddFacultyDialog()
    {
        _ = CreateAddFacultyDialog().ShowDialog();
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
        ManageRoomForm form = new();
        AddRoomPresenter presenter = new(form, addRoomHandler, getFacultiesHandler);
        form.Presenter = presenter;

        return form;
    }

    public Form CreateEditRoomDialog(Room room)
    {
        ManageRoomForm form = new();
        EditRoomPresenter presenter = new(room, form, updateRoomHandler, getFacultiesHandler);
        form.Presenter = presenter;

        return form;
    }

    public void ShowAddRoomDialog()
    {
        _ = CreateAddRoomDialog().ShowDialog();
    }

    public void ShowEditRoomDialog(Room room)
    {
        _ = CreateEditRoomDialog(room).ShowDialog();
    }

    public UserControl CreateReservationListFragment()
    {
        ReservationListControl control = new();
        ReservationListPresenter presenter = new(control, this,
            getReservationsHandler, deleteReservationHandler);
        control.Presenter = presenter;

        return control;
    }

    public Form CreateAddReservationDialog()
    {
        ManageReservationForm form = new();
        AddReservationPresenter presenter = new(form,
            addReservationHandler, getRoomsHandler, getEmployeesHandler);
        form.Presenter = presenter;

        return form;
    }

    public Form CreateEditReservationDialog(Reservation reservation)
    {
        ManageReservationForm form = new();
        EditReservationPresenter presenter = new(reservation, form,
            updateReservationHandler, getRoomsHandler, getEmployeesHandler);
        form.Presenter = presenter;

        return form;
    }

    public void ShowAddReservationDialog()
    {
        _ = CreateAddReservationDialog().ShowDialog();
    }

    public void ShowEditReservationDialog(Reservation reservation)
    {
        _ = CreateEditReservationDialog(reservation).ShowDialog();
    }
}
