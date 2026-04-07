using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Infrastructure.Repositories;

public class InMemoryReservationRepository : IReservationRepository
{
    private Dictionary<Guid, Reservation> _reservations = [];

    public void ReplaceAll(IReadOnlyList<Reservation> reservations)
    {
        _reservations = reservations.ToDictionary(reservation => reservation.Id);
    }

    public void Insert(Reservation reservation)
    {
        if (_reservations.ContainsKey(reservation.Id))
        {
            throw new ArgumentException("Reservation already exists.", nameof(reservation));
        }
        _reservations[reservation.Id] = reservation;
    }

    public IEnumerable<Reservation> GetAll()
    {
        return _reservations.Values;
    }

    public Reservation? GetById(Guid reservationId)
    {
        _ = _reservations.TryGetValue(reservationId, out Reservation? reservation);
        return reservation;
    }

    public IEnumerable<Reservation> GetByRoomIdAndTime(Guid roomId, DateTime start, DateTime end)
    {
        return _reservations.Values
            .Where(reservation => reservation.Room.Id == roomId && ReservationTimeOverlaps(reservation, start, end));
    }

    public IEnumerable<Reservation> GetByEmployeeIdAndTime(Guid employeeId, DateTime start, DateTime end)
    {
        return _reservations.Values
            .Where(reservation => reservation.Employee.Id == employeeId && ReservationTimeOverlaps(reservation, start, end));
    }

    private bool ReservationTimeOverlaps(Reservation reservation, DateTime start, DateTime end)
    {
        return reservation.Start < end && start < reservation.End;
    }

    public bool ExistsById(Guid reservationId)
    {
        return _reservations.ContainsKey(reservationId);
    }

    public void Update(Reservation reservation)
    {
        if (!_reservations.ContainsKey(reservation.Id))
        {
            throw new ArgumentException("Reservation does not exist.", nameof(reservation));
        }
        _reservations[reservation.Id] = reservation;
    }

    public void DeleteById(Guid reservationId)
    {
        _ = _reservations.Remove(reservationId);
    }
}
