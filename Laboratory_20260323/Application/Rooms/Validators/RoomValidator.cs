using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Rooms.Interfaces;
using Laboratory_20260323.Domain.Entities;
using System.Text.RegularExpressions;

namespace Laboratory_20260323.Application.Rooms.Validators;

public partial class RoomDataValidator : IValidator<IRoomData>
{
    [GeneratedRegex(@"^[A-Za-z0-9- .]{1,24}$", RegexOptions.Singleline)]
    private static partial Regex RoomNumberRegex();

    public Dictionary<string, string> Validate(IRoomData room)
    {
        Dictionary<string, (bool IsValid, string Message)> errors = new()
        {
            [nameof(Room.Number)] = ValidateRoomNumber(room.Number),
            [nameof(Room.Capacity)] = ValidateRoomCapacity(room.Capacity),
        };

        return errors.Where(error => !error.Value.IsValid)
            .ToDictionary(error => error.Key, error => error.Value.Message);
    }

    private static (bool, string) ValidateRoomNumber(string number)
    {
        if (RoomNumberRegex().IsMatch(number))
        {
            return (true, string.Empty);
        }
        return (false, "Room name must contain between 1 to 24 letters, numbers, dashes, spaces and dots.");
    }

    private static (bool, string) ValidateRoomCapacity(int capacity)
    {
        if (capacity > 0)
        {
            return (true, string.Empty);
        }
        return (false, "Room has to have at least one available space.");
    }
}
