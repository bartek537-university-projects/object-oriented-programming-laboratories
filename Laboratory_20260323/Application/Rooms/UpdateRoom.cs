using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Rooms;

public class UpdateRoom
{
    public record Command(Guid RoomId, string Number, int Capacity, RoomType Type, Guid? FacultyId) : IRequest<Response>;

    public class Handler(IValidator<Command> validator, IRoomRepository roomRepository, IFacultyRepository facultyRepository)
        : IRequestHandler<Command, Response>
    {
        public Response Handle(Command command)
        {
            ValidateRequest(command);

            Room oldRoom = GetRoomOrThrow(command.RoomId);
            Faculty faculty = GetFacultyOrThrow(command.FacultyId!.Value);

            Room newRoom = new()
            {
                Id = oldRoom.Id,
                Number = command.Number,
                Capacity = command.Capacity,
                Type = command.Type,
                Faculty = faculty
            };

            roomRepository.Update(newRoom);

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

        private Faculty GetFacultyOrThrow(Guid facultyId)
        {
            return facultyRepository.GetById(facultyId) ?? throw new NotFoundException("Faculty does not exist.");
        }
    }

    public record Response();
}
