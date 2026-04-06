using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Reservations.Validators;

public class ReservationValidator : IValidator<AddReservation.Command>, IValidator<UpdateReservation.Command>
{
    public Dictionary<string, string> Validate(AddReservation.Command ac)
    {
        return Validate(new ReservationDetails(ac.RoomId, ac.EmployeeId, ac.Start, ac.End));
    }

    public Dictionary<string, string> Validate(UpdateReservation.Command uc)
    {
        return Validate(new ReservationDetails(uc.RoomId, uc.EmployeeId, uc.Start, uc.End));
    }

    private static Dictionary<string, string> Validate(ReservationDetails reservation)
    {
        IReadOnlyList<(string Field, string? Message)> errors = [
            (nameof(Reservation.Room), ValidateRoom(reservation.RoomId)),
            (nameof(Reservation.Employee), ValidateEmployee(reservation.EmployeeId)),
            (nameof(Reservation.End), ValidateTimeWindow(reservation.Start, reservation.End))
        ];

        return errors.Where(error => error.Message is not null)
            .ToDictionary(error => error.Field, error => error.Message!);
    }

    private static string? ValidateRoom(Guid? id)
    {
        return id is null ? "Room must be specified." : null;
    }

    private static string? ValidateEmployee(Guid? id)
    {
        return id is null ? "Employee must be specified." : null;
    }

    private static string? ValidateTimeWindow(DateTime start, DateTime end)
    {
        return start >= end ? "End time must follow the start time." : null;
    }

    private record ReservationDetails(Guid? RoomId, Guid? EmployeeId, DateTime Start, DateTime End);
}
