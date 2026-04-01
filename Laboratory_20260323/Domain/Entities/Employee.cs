namespace Laboratory_20260323.Domain.Entities;

public class Employee
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}
