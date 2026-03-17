namespace Laboratory_20260309.Domain.Models;

public class Student : IEquatable<Student>
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public required DateTime BirthDate { get; init; }

    public required Address HomeAddress { get; set; }

    public CollegeLevel CollegeLevel { get; set; }

    public bool Equals(Student? other)
    {
        return Id == other?.Id;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName} (ID: {Id})";
    }
}
