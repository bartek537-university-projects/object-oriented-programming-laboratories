using Laboratory_20260323.Application.Employees;
using Laboratory_20260323.Application.Employees.Validators;
using Laboratory_20260323.Application.Faculties;
using Laboratory_20260323.Application.Faculties.Validators;
using Laboratory_20260323.Application.Persistence;
using Laboratory_20260323.Application.Persistence.Mappers;
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

            OnDiskApplicationSnapshotRepository snapshotRepository = new();
            InMemoryEmployeeRepository employeeRepository = new();
            InMemoryFacultyRepository facultyRepository = new();
            InMemoryRoomRepository roomRepository = new();
            InMemoryReservationRepository reservationRepository = new();

            // Persistence
            ApplicationDataMapper applicationDataMapper = new();
            SaveToFile.Handler saveToFileHandler = new(applicationDataMapper, snapshotRepository, employeeRepository, facultyRepository, roomRepository, reservationRepository);
            LoadFromFile.Handler loadFromFileHandler = new(applicationDataMapper, snapshotRepository, employeeRepository, facultyRepository, roomRepository, reservationRepository);

            // Employees
            EmployeeValidator employeeValidator = new();
            AddEmployee.Handler addEmployeeHandler = new(employeeValidator, employeeRepository);
            GetEmployees.Handler getEmployeesHandler = new(employeeRepository);
            UpdateEmployee.Handler updateEmployeeHandler = new(employeeValidator, employeeRepository);
            DeleteEmployee.Handler deleteEmployeeHandler = new(employeeRepository);

            // Faculties
            FacultyValidator facultyValidator = new();
            AddFaculty.Handler addFacultyHandler = new(facultyValidator, facultyRepository);
            GetFaculties.Handler getFacultiesHandler = new(facultyRepository);
            UpdateFaculty.Handler updateFacultyHandler = new(facultyValidator, facultyRepository);
            DeleteFaculty.Handler deleteFacultyHandler = new(facultyRepository);

            // Rooms
            RoomValidator roomValidator = new();
            AddRoom.Handler addRoomHandler = new(roomValidator, roomRepository, facultyRepository);
            GetRooms.Handler getRoomsHandler = new(roomRepository);
            UpdateRoom.Handler updateRoomHandler = new(roomValidator, roomRepository, facultyRepository);
            DeleteRoom.Handler deleteRoomHandler = new(roomRepository);

            // Reservations
            ReservationValidator reservationValidator = new();
            AddReservation.Handler addReservationHandler = new(reservationValidator, reservationRepository, roomRepository, employeeRepository);
            GetReservations.Handler getReservationsHandler = new(reservationRepository);
            UpdateReservation.Handler updateReservationHandler = new(reservationValidator, reservationRepository, roomRepository, employeeRepository);
            DeleteReservation.Handler deleteReservationHandler = new(reservationRepository);

            WindowService windowService = new(
                saveToFileHandler, loadFromFileHandler,
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