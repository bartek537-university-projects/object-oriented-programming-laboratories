namespace Laboratory_20260323.Domain.Entities;

public class Reservation
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required Room Room { get; set; }
    public required Employee Employee { get; set; }
    public required DateTime Start { get; set; }
    public required DateTime End { get; set; }
}