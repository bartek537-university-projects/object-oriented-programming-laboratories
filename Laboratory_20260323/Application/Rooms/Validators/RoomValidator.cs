using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Domain.Entities;
using System.Text.RegularExpressions;

namespace Laboratory_20260323.Application.Rooms.Validators;

public partial class RoomValidator : IValidator<AddRoom.Command>, IValidator<UpdateRoom.Command>
{
    [GeneratedRegex(@"^[A-Za-z0-9- .]{1,24}$", RegexOptions.Singleline)]
    private static partial Regex RoomNumberRegex();

    public Dictionary<string, string> Validate(AddRoom.Command ac)
    {
        return Validate(new RoomDetails(ac.Number, ac.Capacity, ac.FacultyId));
    }

    public Dictionary<string, string> Validate(UpdateRoom.Command uc)
    {
        return Validate(new RoomDetails(uc.Number, uc.Capacity, uc.FacultyId));
    }

    private static Dictionary<string, string> Validate(RoomDetails room)
    {
        IReadOnlyList<(string Field, string? Message)> errors = [
            (nameof(Room.Number), ValidateRoomNumber(room.Number)),
            (nameof(Room.Capacity), ValidateRoomCapacity(room.Capacity)),
            (nameof(Room.Faculty), ValidateFaculty(room.FacultyId)),
        ];

        return errors.Where(error => error.Message is not null)
            .ToDictionary(error => error.Field, error => error.Message!);
    }

    private static string? ValidateRoomNumber(string number)
    {
        return !RoomNumberRegex().IsMatch(number) ? "Room name must contain between 1 to 24 letters, numbers, dashes, spaces and dots." : null;
    }

    private static string? ValidateRoomCapacity(int capacity)
    {
        return capacity <= 0 ? "Room has to have at least one available space." : null;
    }

    private static string? ValidateFaculty(Guid? id)
    {
        return id is null ? "Faculty must be specified." : null;
    }

    private record RoomDetails(string Number, int Capacity, Guid? FacultyId);
}
