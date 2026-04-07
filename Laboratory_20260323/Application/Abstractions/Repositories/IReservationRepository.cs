using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Abstractions.Repositories;

public interface IReservationRepository
{
    void ReplaceAll(IReadOnlyList<Reservation> reservations);

    void Insert(Reservation reservation);

    IEnumerable<Reservation> GetAll();
    Reservation? GetById(Guid reservationId);
    IEnumerable<Reservation> GetByRoomIdAndTime(Guid roomId, DateTime start, DateTime end);
    IEnumerable<Reservation> GetByEmployeeIdAndTime(Guid employeeId, DateTime start, DateTime end);

    bool ExistsById(Guid reservationId);

    void Update(Reservation reservation);

    void DeleteById(Guid reservationId);
}
