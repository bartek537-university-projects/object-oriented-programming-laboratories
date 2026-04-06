using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Abstractions.Repositories;

public interface IReservationRepository
{
    void Insert(Reservation reservation);

    IEnumerable<Reservation> GetAll();
    Reservation? GetById(Guid reservationId);

    bool ExistsById(Guid reservationId);
    bool ExistsByRoomIdAndTime(Guid roomId, DateTime start, DateTime end);
    bool ExistsByEmployeeIdAndTime(Guid employeeId, DateTime start, DateTime end);

    void Update(Reservation reservation);

    void DeleteById(Guid reservationId);
}
