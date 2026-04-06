using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Reservations.Validators;

public class ReservationValidator : IValidator<AddReservation.Command>, IValidator<UpdateReservation.Command>
{
    public Dictionary<string, string> Validate(AddReservation.Command reservation)
    {
        return Validate(new ReservationDetails(reservation.Start, reservation.End));
    }

    public Dictionary<string, string> Validate(UpdateReservation.Command reservation)
    {
        return Validate(new ReservationDetails(reservation.Start, reservation.End));
    }

    private static Dictionary<string, string> Validate(ReservationDetails reservation)
    {
        IReadOnlyList<(string Field, string? Message)> errors = [
            (nameof(Reservation.End), ValidateTimeWindow(reservation.Start, reservation.End))
        ];

        return errors
            .Where(error => error.Message is not null)
            .ToDictionary(error => error.Field, error => error.Message!);
    }

    private static string? ValidateTimeWindow(DateTime start, DateTime end)
    {
        return start < end ? null : "End time must follow the start time.";
    }

    private record ReservationDetails(DateTime Start, DateTime End);
}
