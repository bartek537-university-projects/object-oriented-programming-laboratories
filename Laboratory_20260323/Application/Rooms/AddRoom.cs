using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Application.Rooms.Interfaces;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Rooms;

public class AddRoom
{
    public record Command(string Number, int Capacity, RoomType Type, Guid FacultyId) : IRoomData;

    public class Handler(IValidator<IRoomData> validator, IRoomRepository roomRepository, IFacultyRepository facultyRepository)
        : IAddRoomHandler
    {
        public Response Handle(Command command)
        {
            ValidateRoomDetails(command);
            ValidateFacultyExists(command.FacultyId);

            Room room = CreateRoom(command);
            roomRepository.Insert(room);

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
                    Number = command.Number,
                    Capacity = command.Capacity,
                    Type = command.Type,
                    Faculty = faculty
                };
        }
    }

    public record Response();
}

public interface IAddRoomHandler
{
    AddRoom.Response Handle(AddRoom.Command command);
}
