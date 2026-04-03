namespace Laboratory_20260323.Domain.Entities;

public class Room
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public required string Number { get; set; }
    public required int Capacity { get; set; }
    public required RoomType Type { get; set; }

    public required Faculty Faculty { get; set; }
}
