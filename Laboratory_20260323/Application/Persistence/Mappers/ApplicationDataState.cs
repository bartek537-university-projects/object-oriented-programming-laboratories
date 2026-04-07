using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Persistence.Mappers;

public class ApplicationDataState
{
    public required IReadOnlyList<Employee> Employees { get; init; }
    public required IReadOnlyList<Faculty> Faculties { get; init; }
    public required IReadOnlyList<Room> Rooms { get; init; }
    public required IReadOnlyList<Reservation> Reservations { get; init; }
}
