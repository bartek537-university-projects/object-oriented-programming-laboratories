namespace Laboratory_20260309.Domain.Models;

public class Student : IEquatable<Student>
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public required string Imie { get; set; }
    public required string Nazwisko { get; set; }

    public required DateTime DataUrodzenia { get; init; }

    public required Adres AdresZamieszkania { get; set; }

    public RokStudiow RokStudiow { get; set; }

    public bool Equals(Student? other)
    {
        return Id == other?.Id;
    }

    public override string ToString()
    {
        return $"{Imie} {Nazwisko} (ID: {Id})";
    }
}
