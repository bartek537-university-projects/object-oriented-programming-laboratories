using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Persistence.Mappers;

public class ApplicationDataSnapshot
{
    public required IReadOnlyList<EmployeeSnapshot> Employees { get; init; }
    public required IReadOnlyList<FacultySnapshot> Faculties { get; init; }
    public required IReadOnlyList<RoomSnapshot> Rooms { get; init; }
    public required IReadOnlyList<ReservationSnapshot> Reservations { get; init; }
}

public class EmployeeSnapshot
{
    public required Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}

public class FacultySnapshot
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required AddressSnapshot Address { get; set; }
}

public class AddressSnapshot
{
    public required string City { get; set; }
    public required string PostalCode { get; set; }
    public required string Street { get; set; }
    public required string Building { get; set; }
}

public class RoomSnapshot
{
    public required Guid Id { get; set; }
    public required string Number { get; set; }
    public required int Capacity { get; set; }
    public required RoomType Type { get; set; }
    public required Guid FacultyId { get; set; }
}

public class ReservationSnapshot
{
    public required Guid Id { get; init; } = Guid.NewGuid();
    public required Guid RoomId { get; set; }
    public required Guid EmployeeId { get; set; }
    public required DateTime Start { get; set; }
    public required DateTime End { get; set; }
}
