namespace Laboratory_20260323.Domain.Entities;

public class Faculty
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public required string Name { get; set; }

    public required Address Address { get; set; }
}
