using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Persistence.Mappers;

public class ApplicationDataMapper : IApplicationDataMapper
{
    public ApplicationDataSnapshot ToSnapshot(ApplicationDataState state)
    {
        return new ApplicationDataSnapshot
        {
            Employees = [.. state.Employees.Select(MapEmployeeToSnapshot)],
            Faculties = [.. state.Faculties.Select(MapFacultyToSnapshot)],
            Rooms = [.. state.Rooms.Select(MapRoomToSnapshot)],
            Reservations = [.. state.Reservations.Select(MapReservationToSnapshot)],
        };
    }

    public ApplicationDataState ToDomain(ApplicationDataSnapshot snapshot)
    {
        Dictionary<Guid, Employee> employees = snapshot.Employees.Select(MapEmployeeToDomain).ToDictionary(value => value.Id);
        Dictionary<Guid, Faculty> faculties = snapshot.Faculties.Select(MapFacultyToDomain).ToDictionary(value => value.Id);
        Dictionary<Guid, Room> rooms = snapshot.Rooms.Select(room => MapRoomToDomain(room, faculties)).ToDictionary(value => value.Id);
        List<Reservation> reservations = [.. snapshot.Reservations.Select(reservation => MapReservationToDomain(reservation, rooms, employees))];

        return new ApplicationDataState
        {
            Employees = [.. employees.Values],
            Faculties = [.. faculties.Values],
            Rooms = [.. rooms.Values],
            Reservations = reservations
        };
    }

    private static EmployeeSnapshot MapEmployeeToSnapshot(Employee employee)
    {
        return new()
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName
        };
    }

    private static FacultySnapshot MapFacultyToSnapshot(Faculty faculty)
    {
        return new()
        {
            Id = faculty.Id,
            Name = faculty.Name,
            Address = new()
            {
                City = faculty.Address.City,
                PostalCode = faculty.Address.PostalCode,
                Street = faculty.Address.Street,
                Building = faculty.Address.Building,
            }
        };
    }

    private static RoomSnapshot MapRoomToSnapshot(Room room)
    {
        return new()
        {
            Id = room.Id,
            Number = room.Number,
            Capacity = room.Capacity,
            Type = room.Type,
            FacultyId = room.Faculty.Id
        };
    }

    private static ReservationSnapshot MapReservationToSnapshot(Reservation reservation)
    {
        return new()
        {
            Id = reservation.Id,
            RoomId = reservation.Room.Id,
            EmployeeId = reservation.Employee.Id,
            Start = reservation.Start,
            End = reservation.End
        };
    }

    private static Employee MapEmployeeToDomain(EmployeeSnapshot employee)
    {
        return new()
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName
        };
    }

    private static Faculty MapFacultyToDomain(FacultySnapshot faculty)
    {
        return new()
        {
            Id = faculty.Id,
            Name = faculty.Name,
            Address = new()
            {
                City = faculty.Address.City,
                PostalCode = faculty.Address.PostalCode,
                Street = faculty.Address.Street,
                Building = faculty.Address.Building
            }
        };
    }

    private static Room MapRoomToDomain(RoomSnapshot room, Dictionary<Guid, Faculty> faculties)
    {
        return new()
        {
            Id = room.Id,
            Number = room.Number,
            Capacity = room.Capacity,
            Type = room.Type,
            Faculty = faculties[room.FacultyId]
        };
    }

    private static Reservation MapReservationToDomain(ReservationSnapshot reservation, Dictionary<Guid, Room> rooms, Dictionary<Guid, Employee> employees)
    {
        return new()
        {
            Id = reservation.Id,
            Room = rooms[reservation.RoomId],
            Employee = employees[reservation.EmployeeId],
            Start = reservation.Start,
            End = reservation.End,
        };
    }
}
