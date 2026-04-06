using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;

namespace Laboratory_20260323.Application.Reservations;

public class DeleteReservation
{
    public record Command(Guid ReservationId) : IRequest<Response>;

    public class Handler(IReservationRepository repository)
        : IRequestHandler<Command, Response>
    {
        public Response Handle(Command request)
        {
            ValidateReservationExists(request.ReservationId);

            repository.DeleteById(request.ReservationId);

            return new Response();
        }

        private void ValidateReservationExists(Guid reservationId)
        {
            if (!repository.ExistsById(reservationId))
            {
                throw new ArgumentException("Reservation does not exist.", nameof(reservationId));
            }
        }
    }

    public record Response();
}
