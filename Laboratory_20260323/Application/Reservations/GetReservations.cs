using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Reservations;

public class GetReservations
{
    public record Query() : IRequest<Response>;

    public class Handler(IReservationRepository repository)
        : IRequestHandler<Query, Response>
    {
        public Response Handle(Query query)
        {
            List<Reservation> reservations = [.. repository.GetAll()];
            return new Response(reservations);
        }
    }

    public record Response(IReadOnlyList<Reservation> Reservations);
}