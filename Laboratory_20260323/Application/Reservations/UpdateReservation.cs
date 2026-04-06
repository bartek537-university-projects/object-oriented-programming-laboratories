using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Reservations;

public class UpdateReservation
{
    public record Command(Guid ReservationId, Guid? RoomId, Guid? EmployeeId, DateTime Start, DateTime End) : IRequest<Response>;

    public class Handler(IValidator<Command> validator, IReservationRepository reservationRepository, IRoomRepository roomRepository, IEmployeeRepository employeeRepository)
        : IRequestHandler<Command, Response>
    {
        public Response Handle(Command command)
        {
            ValidateRequest(command);

            Reservation oldReservation = GetReservationOrThrow(command.ReservationId);
            Room room = GetRoomOrThrow(command.RoomId!.Value);
            Employee employee = GetEmployeeOrThrow(command.EmployeeId!.Value);

            EnsureAvailability(oldReservation.Id, room, employee, command.Start, command.End);

            Reservation newReservation = new()
            {
                Id = oldReservation.Id,
                Room = room,
                Employee = employee,
                Start = command.Start,
                End = command.End
            };

            reservationRepository.Update(newReservation);
            return new Response();
        }

        private void ValidateRequest(Command command)
        {
            if (validator.Validate(command) is { Count: > 0 } errors)
            {
                throw new ValidationException(errors);
            }
        }

        private Reservation GetReservationOrThrow(Guid reservationId)
        {
            return reservationRepository.GetById(reservationId) ?? throw new NotFoundException("Reservation does not exist.");
        }

        private Room GetRoomOrThrow(Guid roomId)
        {
            return roomRepository.GetById(roomId) ?? throw new NotFoundException("Room does not exist.");
        }

        private Employee GetEmployeeOrThrow(Guid employeeId)
        {
            return employeeRepository.GetById(employeeId) ?? throw new NotFoundException("Employee does not exist.");
        }

        private void EnsureAvailability(Guid reservationId, Room room, Employee employee, DateTime start, DateTime end)
        {
            if (IsRoomOccupied(room, start, end, reservationId))
            {
                throw new ConflictException("Room is occupied at that time.", nameof(Reservation.Room));
            }
            if (IsEmployeeOccupied(employee, start, end, reservationId))
            {
                throw new ConflictException("Employee is occupied at that time.", nameof(Reservation.Employee));
            }
        }

        private bool IsRoomOccupied(Room room, DateTime start, DateTime end, Guid reservationId)
        {
            return reservationRepository.GetByRoomIdAndTime(room.Id, start, end).Any(reservation => reservation.Id != reservationId);
        }

        private bool IsEmployeeOccupied(Employee employee, DateTime start, DateTime end, Guid reservationId)
        {
            return reservationRepository.GetByEmployeeIdAndTime(employee.Id, start, end).Any(reservation => reservation.Id != reservationId);
        }
    }

    public record Response();
}
