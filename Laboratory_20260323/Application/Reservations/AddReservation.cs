using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Reservations;

public class AddReservation
{
    public record Command(Guid RoomId, Guid EmployeeId, DateTime Start, DateTime End) : IRequest<Response>;

    public class Handler(IValidator<Command> validator, IReservationRepository reservationRepository, IRoomRepository roomRepository, IEmployeeRepository employeeRepository)
        : IRequestHandler<Command, Response>
    {
        public Response Handle(Command command)
        {
            ValidateRequest(command);

            Room room = GetRoomOrThrow(command.RoomId);
            Employee employee = GetEmployeeOrThrow(command.EmployeeId);

            EnsureAvailability(room, employee, command.Start, command.End);

            Reservation reservation = new()
            {
                Room = room,
                Employee = employee,
                Start = command.Start,
                End = command.End
            };

            reservationRepository.Insert(reservation);
            return new Response();
        }

        private void ValidateRequest(Command command)
        {
            if (validator.Validate(command) is { Count: > 0 } errors)
            {
                throw new ValidationException(errors);
            }
        }

        private Room GetRoomOrThrow(Guid roomId)
        {
            return roomRepository.GetById(roomId) ?? throw new NotFoundException("Room does not exist.");
        }

        private Employee GetEmployeeOrThrow(Guid employeeId)
        {
            return employeeRepository.GetById(employeeId) ?? throw new NotFoundException("Employee does not exist.");
        }

        private void EnsureAvailability(Room room, Employee employee, DateTime start, DateTime end)
        {
            if (reservationRepository.ExistsByRoomIdAndTime(employee.Id, start, end))
            {
                throw new ConflictException("Room is occupied at that time.");
            }
            if (reservationRepository.ExistsByEmployeeIdAndTime(employee.Id, start, end))
            {
                throw new ConflictException("Employee is occupied at that time.");
            }
        }
    }

    public record Response();
}
