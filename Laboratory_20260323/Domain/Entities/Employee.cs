namespace Laboratory_20260323.Domain.Entities;

public class Employee
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}
