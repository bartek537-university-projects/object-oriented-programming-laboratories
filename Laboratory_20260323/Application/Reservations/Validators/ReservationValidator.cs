using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Reservations.Validators;

public class ReservationValidator : IValidator<AddReservation.Command>, IValidator<UpdateReservation.Command>
{
    public Dictionary<string, string> Validate(AddReservation.Command reservation)
    {
        return Validate(new ReservationDetails(reservation.RoomId, reservation.EmployeeId, reservation.Start, reservation.End));
    }

    public Dictionary<string, string> Validate(UpdateReservation.Command reservation)
    {
        return Validate(new ReservationDetails(reservation.RoomId, reservation.EmployeeId, reservation.Start, reservation.End));
    }

    private static Dictionary<string, string> Validate(ReservationDetails reservation)
    {
        IReadOnlyList<(string Field, string? Message)> errors = [
            (nameof(Reservation.Room), ValidateRoom(reservation.RoomId)),
            (nameof(Reservation.Employee), ValidateEmployee(reservation.EmployeeId)),
            (nameof(Reservation.End), ValidateTimeWindow(reservation.Start, reservation.End))
        ];

        return errors
            .Where(error => error.Message is not null)
            .ToDictionary(error => error.Field, error => error.Message!);
    }

    private static string? ValidateRoom(object? obj)
    {
        return obj is null ? "Room must be specified." : null;
    }

    private static string? ValidateEmployee(object? obj)
    {
        return obj is null ? "Employee must be specified." : null;
    }

    private static string? ValidateTimeWindow(DateTime start, DateTime end)
    {
        return start >= end ? "End time must follow the start time." : null;
    }

    private record ReservationDetails(Guid? RoomId, Guid? EmployeeId, DateTime Start, DateTime End);
}
