using Laboratory_20260309.Domain.Models;
using System.Text.RegularExpressions;

namespace Laboratory_20260309;

public partial class StudentFormDto
{
    public required string FirstName { get; set => field = value.Trim(); }
    public required string LastName { get; set => field = value.Trim(); }
    public required DateTime BirthDate { get; set; }
    public required CollegeLevel CollegeLevel { get; set; }
    public required string City { get; set => field = value.Trim(); }
    public required string PostalCode { get; set => field = value.Trim(); }
    public required string Street { get; set => field = value.Trim(); }
    public required int BuildingNumber { get; set; }
    public required int? FlatNumber { get; set; }

    [GeneratedRegex(@"^\d{2}-\d{3}$")]
    private static partial Regex PostalCodeRegex();

    public Dictionary<string, string> Validate()
    {
        var statuses = new Dictionary<string, (bool IsValid, string Message)>
        {
            [nameof(FirstName)] = ValidateFirstName(),
            [nameof(LastName)] = ValidateLastName(),
            [nameof(BirthDate)] = ValidateBirthDate(),
            [nameof(City)] = ValidateCity(),
            [nameof(PostalCode)] = ValidatePostalCode(),
            [nameof(Street)] = ValidateStreet()
        };

        var errors = statuses.Where(entry => !entry.Value.IsValid)
            .ToDictionary(entry => entry.Key, entry => entry.Value.Message);

        return errors;
    }

    private (bool, string) ValidateFirstName()
    {
        return ValidateLength(FirstName, 1, 32);
    }

    private (bool, string) ValidateLastName()
    {
        return ValidateLength(LastName, 1, 64);
    }

    private (bool, string) ValidateBirthDate()
    {
        if (BirthDate > DateTime.Now)
        {
            return (false, "Data nie może leżeć w przyszłości.");
        }
        return (true, string.Empty);
    }

    private (bool, string) ValidateCity()
    {
        return ValidateLength(LastName, 1, 64);
    }

    private (bool, string) ValidatePostalCode()
    {
        if (!PostalCodeRegex().IsMatch(PostalCode))
        {
            return (false, "Niepoprawny kod pocztowy.");
        }
        return (true, string.Empty);
    }

    private (bool, string) ValidateStreet()
    {
        return ValidateLength(LastName, 1, 80);
    }

    private static (bool, string) ValidateLength(string value, int min, int max)
    {
        if (value.Length < min || value.Length > max)
        {
            return (false, $"Pole musi zawierać między {min}, a {max} znaki.");
        }
        return (true, string.Empty);
    }
}
