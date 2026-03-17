namespace Laboratory_20260309.Domain.Models;

internal class Student
{
    public Guid Id { get; } = Guid.NewGuid();

    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public required DateTime BirthDate { get; init; }

    public required Address HomeAddress { get; set; }

    public CollegeLevel CollegeLevel { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName} (ID: {Id})";
    }
}
