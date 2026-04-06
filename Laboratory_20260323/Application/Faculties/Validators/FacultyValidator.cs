using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Domain.Entities;
using System.Text.RegularExpressions;

namespace Laboratory_20260323.Application.Faculties.Validators;

public partial class FacultyValidator : IValidator<AddFaculty.Command>, IValidator<UpdateFaculty.Command>
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

    public Dictionary<string, string> Validate(AddFaculty.Command ac)
    {
        return Validate(new FacultyDetails(ac.Name, ac.City, ac.PostalCode, ac.Street, ac.Building));
    }

    public Dictionary<string, string> Validate(UpdateFaculty.Command uc)
    {
        return Validate(new FacultyDetails(uc.Name, uc.City, uc.PostalCode, uc.Street, uc.Building));
    }

    private Dictionary<string, string> Validate(FacultyDetails faculty)
    {
        IReadOnlyList<(string Field, string? Message)> errors = [
            (nameof(Faculty.Name), ValidateFacultyName(faculty.Name)),
            (nameof(Faculty.Address.City), ValidateCity(faculty.City)),
            (nameof(Faculty.Address.PostalCode), ValidatePostalCode(faculty.PostalCode)),
            (nameof(Faculty.Address.Street), ValidateStreet(faculty.Street)),
            (nameof(Faculty.Address.Building), ValidateBuilding(faculty.Building)),
        ];

        return errors.Where(error => error.Message is not null)
            .ToDictionary(error => error.Field, error => error.Message!);
    }

    private static string? ValidateFacultyName(string name)
    {
        return !FacultyNameRegex().IsMatch(name) ? "Faculty name must contain between 2 to 128 letters, spaces and dashes." : null;
    }

    private static string? ValidateCity(string city)
    {
        return !CityRegex().IsMatch(city) ? "City name must contain between 2 to 48 letters, spaces and dashes." : null;
    }

    private static string? ValidatePostalCode(string postalCode)
    {
        return !PostalCodeRegex().IsMatch(postalCode) ? "Postal code must consist of 2 digits, a dash and 3 digits." : null;
    }

    private static string? ValidateStreet(string street)
    {
        return !StreetRegex().IsMatch(street) ? "Street name must contain between 2 to 48 letters, numbers, spaces and dashes." : null;
    }

    private static string? ValidateBuilding(string name)
    {
        return !BuildingRegex().IsMatch(name) ? "Building number must contain between 2 to 32 letters, numbers and spaces." : null;
    }

    private record FacultyDetails(string Name, string City, string PostalCode, string Street, string Building);
}