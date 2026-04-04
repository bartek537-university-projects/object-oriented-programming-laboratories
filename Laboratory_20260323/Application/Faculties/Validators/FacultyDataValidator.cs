using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Faculties.Interfaces;
using Laboratory_20260323.Domain.Entities;
using System.Text.RegularExpressions;

namespace Laboratory_20260323.Application.Faculties.Validators;

public partial class FacultyDataValidator : IValidator<IFacultyData>
{
    [GeneratedRegex(@"^[A-Za-z- ]{2,128}$", RegexOptions.Singleline)]
    private static partial Regex FacultyNameRegex();
    [GeneratedRegex(@"^[A-Za-z- ]{2,48}$", RegexOptions.Singleline)]
    private static partial Regex CityRegex();
    [GeneratedRegex(@"^[0-9]{2}-[0-9]{3}$", RegexOptions.Singleline)]
    private static partial Regex PostalCodeRegex();
    [GeneratedRegex(@"^[A-Za-z0-9 -]{2,48}$", RegexOptions.Singleline)]
    private static partial Regex StreetRegex();
    [GeneratedRegex(@"^[A-Za-z0-9 ]{2,32}$", RegexOptions.Singleline)]
    private static partial Regex BuildingRegex();

    public Dictionary<string, string> Validate(IFacultyData faculty)
    {
        Dictionary<string, (bool IsValid, string Message)> errors = new()
        {
            [nameof(Faculty.Name)] = ValidateFacultyName(faculty.Name),
            [nameof(Faculty.Address.City)] = ValidateCity(faculty.City),
            [nameof(Faculty.Address.PostalCode)] = ValidatePostalCode(faculty.PostalCode),
            [nameof(Faculty.Address.Street)] = ValidateStreet(faculty.Street),
            [nameof(Faculty.Address.Building)] = ValidateBuilding(faculty.Building),
        };

        return errors.Where(error => !error.Value.IsValid)
            .ToDictionary(error => error.Key, error => error.Value.Message);
    }

    private static (bool, string) ValidateFacultyName(string name)
    {
        if (FacultyNameRegex().IsMatch(name))
        {
            return (true, string.Empty);
        }
        return (false, "Faculty name must contain between 2 to 128 letters, spaces and dashes.");
    }

    private static (bool, string) ValidateCity(string name)
    {
        if (CityRegex().IsMatch(name))
        {
            return (true, string.Empty);
        }
        return (false, "City name must contain between 2 to 48 letters, spaces and dashes.");
    }

    private static (bool, string) ValidatePostalCode(string name)
    {
        if (PostalCodeRegex().IsMatch(name))
        {
            return (true, string.Empty);
        }
        return (false, "Postal code must consist of 2 digits, a dash and 3 digits.");
    }

    private static (bool, string) ValidateStreet(string name)
    {
        if (StreetRegex().IsMatch(name))
        {
            return (true, string.Empty);
        }
        return (false, "Street name must contain between 2 to 48 letters, numbers, spaces and dashes.");
    }

    private static (bool, string) ValidateBuilding(string name)
    {
        if (BuildingRegex().IsMatch(name))
        {
            return (true, string.Empty);
        }
        return (false, "Building number must contain between 2 to 32 letters, numbers and spaces.");
    }
}