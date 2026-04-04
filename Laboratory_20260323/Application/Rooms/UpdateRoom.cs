using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Application.Rooms.Interfaces;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Rooms;

public class UpdateRoom
{
    public record Command(Guid RoomId, string Number, int Capacity, RoomType Type, Guid FacultyId) : IRoomData;

    public class Handler(IValidator<IRoomData> validator, IRoomRepository roomRepository, IFacultyRepository facultyRepository)
        : IUpdateRoomHandler
    {
        public Response Handle(Command command)
        {
            ValidateRoomDetails(command);
            ValidateRoomExists(command.RoomId);
            ValidateFacultyExists(command.FacultyId);

            Room room = CreateRoom(command);
            roomRepository.Update(room);

            return new Response();
        }

        private void ValidateRoomDetails(Command command)
        {
            Dictionary<string, string> errors = validator.Validate(command);

            if (errors.Count > 0)
            {
                throw new ValidationException(errors);
            }
        }

        private void ValidateRoomExists(Guid roomId)
        {
            if (!roomRepository.ExistsById(roomId))
            {
                throw new ArgumentException("Room does not exist.", nameof(roomId));
            }
        }

        private void ValidateFacultyExists(Guid facultyId)
        {
            if (!facultyRepository.ExistsById(facultyId))
            {
                throw new ArgumentException("Faculty does not exist.", nameof(facultyId));
            }
        }

        private Room CreateRoom(Command command)
        {
            return facultyRepository.GetById(command.FacultyId) is not { } faculty
                ? throw new ArgumentException("Faculty does not exist.", nameof(command))
                : new()
                {
                    Id = command.RoomId,
                    Number = command.Number,
                    Capacity = command.Capacity,
                    Type = command.Type,
                    Faculty = faculty
                };
        }
    }

    public record Response();
}

public interface IUpdateRoomHandler
{
    UpdateRoom.Response Handle(UpdateRoom.Command command);
}
