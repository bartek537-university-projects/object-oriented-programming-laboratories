using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Employees;
using Laboratory_20260323.Application.Faculties;
using Laboratory_20260323.Application.Persistence;
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
    IRequestHandler<SaveToFile.Command, SaveToFile.Response> saveToFileHandler,
    IRequestHandler<LoadFromFile.Command, LoadFromFile.Response> loadFromFileHandler,
    IRequestHandler<AddEmployee.Command, AddEmployee.Response> addEmployeeHandler,
    IRequestHandler<GetEmployees.Query, GetEmployees.Response> getEmployeesHandler,
    IRequestHandler<UpdateEmployee.Command, UpdateEmployee.Response> updateEmployeeHandler,
    IRequestHandler<DeleteEmployee.Command, DeleteEmployee.Response> deleteEmployeeHandler,
    IRequestHandler<AddFaculty.Command, AddFaculty.Response> addFacultyHandler,
    IRequestHandler<GetFaculties.Query, GetFaculties.Response> getFacultiesHandler,
    IRequestHandler<UpdateFaculty.Command, UpdateFaculty.Response> updateFacultyHandler,
    IRequestHandler<DeleteFaculty.Command, DeleteFaculty.Response> deleteFacultyHandler,
    IRequestHandler<AddRoom.Command, AddRoom.Response> addRoomHandler,
    IRequestHandler<GetRooms.Query, GetRooms.Response> getRoomsHandler,
    IRequestHandler<UpdateRoom.Command, UpdateRoom.Response> updateRoomHandler,
    IRequestHandler<DeleteRoom.Command, DeleteRoom.Response> deleteRoomHandler,
    IRequestHandler<AddReservation.Command, AddReservation.Response> addReservationHandler,
    IRequestHandler<GetReservations.Query, GetReservations.Response> getReservationsHandler,
    IRequestHandler<UpdateReservation.Command, UpdateReservation.Response> updateReservationHandler,
    IRequestHandler<DeleteReservation.Command, DeleteReservation.Response> deleteReservationHandler
) : IWindowService
{
    public Form CreateMainWindow()
    {
        MainForm form = new();
        MainPresenter presenter = new(form, this, saveToFileHandler, loadFromFileHandler);
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
