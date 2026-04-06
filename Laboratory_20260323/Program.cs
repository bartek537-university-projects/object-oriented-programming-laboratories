using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Application.Employees;
using Laboratory_20260323.Application.Employees.Validators;
using Laboratory_20260323.Application.Faculties;
using Laboratory_20260323.Application.Faculties.Validators;
using Laboratory_20260323.Application.Reservations;
using Laboratory_20260323.Application.Reservations.Validators;
using Laboratory_20260323.Application.Rooms;
using Laboratory_20260323.Application.Rooms.Validators;
using Laboratory_20260323.Infrastructure.Repositories;
using Laboratory_20260323.Presentation;

namespace Laboratory_20260323
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();

            IEmployeeRepository employeeRepository = new InMemoryEmployeeRepository();
            IFacultyRepository facultyRepository = new InMemoryFacultyRepository();
            IRoomRepository roomRepository = new InMemoryRoomRepository();
            IReservationRepository reservationRepository = new InMemoryReservationRepository();

            EmployeeValidator employeeValidator = new();
            FacultyValidator facultyValidator = new();
            RoomValidator roomValidator = new();
            ReservationValidator reservationValidator = new();

            AddEmployee.Handler addEmployeeHandler = new(employeeValidator, employeeRepository);
            GetEmployees.Handler getEmployeesHandler = new(employeeRepository);
            UpdateEmployee.Handler updateEmployeeHandler = new(employeeValidator, employeeRepository);
            DeleteEmployee.Handler deleteEmployeeHandler = new(employeeRepository);

            AddFaculty.Handler addFacultyHandler = new(facultyValidator, facultyRepository);
            GetFaculties.Handler getFacultiesHandler = new(facultyRepository);
            UpdateFaculty.Handler updateFacultyHandler = new(facultyValidator, facultyRepository);
            DeleteFaculty.Handler deleteFacultyHandler = new(facultyRepository);

            AddRoom.Handler addRoomHandler = new(roomValidator, roomRepository, facultyRepository);
            GetRooms.Handler getRoomsHandler = new(roomRepository);
            UpdateRoom.Handler updateRoomHandler = new(roomValidator, roomRepository, facultyRepository);
            DeleteRoom.Handler deleteRoomHandler = new(roomRepository);

            AddReservation.Handler addReservationHandler = new(reservationValidator, reservationRepository, roomRepository, employeeRepository);
            GetReservations.Handler getReservationsHandler = new(reservationRepository);
            UpdateReservation.Handler updateReservationHandler = new(reservationValidator, reservationRepository, roomRepository, employeeRepository);
            DeleteReservation.Handler deleteReservationHandler = new(reservationRepository);

            WindowService windowService = new(
                addEmployeeHandler, getEmployeesHandler, updateEmployeeHandler, deleteEmployeeHandler,
                addFacultyHandler, getFacultiesHandler, updateFacultyHandler, deleteFacultyHandler,
                addRoomHandler, getRoomsHandler, updateRoomHandler, deleteRoomHandler,
                addReservationHandler, getReservationsHandler, updateReservationHandler, deleteReservationHandler
            );

            System.Windows.Forms.Application
                .Run(windowService.CreateMainWindow());
        }
    }
}