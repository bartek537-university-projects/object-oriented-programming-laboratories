using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Reservations;

public class DeleteReservation
{
    public record Command(Guid ReservationId) : IRequest<Response>;

    public class Handler(IReservationRepository repository)
        : IRequestHandler<Command, Response>
    {
        public Response Handle(Command request)
        {
            Reservation reservation = GetReservationOrThrow(request.ReservationId);

            repository.DeleteById(reservation.Id);

            return new Response();
        }

        private Reservation GetReservationOrThrow(Guid reservationId)
        {
            return repository.GetById(reservationId) ?? throw new NotFoundException("Reservation does not exist.");
        }
    }

    public record Response();
}
