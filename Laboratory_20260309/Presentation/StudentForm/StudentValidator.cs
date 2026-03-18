using System.Text.RegularExpressions;

namespace Laboratory_20260309.Presentation.StudentForm;

internal partial class StudentValidator
{
    [GeneratedRegex(@"^\d{2}-\d{3}$")] private static partial Regex PostalCodeRegex();

    public Dictionary<string, string> Validate(StudentInput student)
    {
        var errors = new Dictionary<string, string?>
        {
            [nameof(StudentInput.FirstName)] = ValidateFirstName(student.FirstName),
            [nameof(StudentInput.LastName)] = ValidateLastName(student.LastName),
            [nameof(StudentInput.BirthDate)] = ValidateBirthDate(student.BirthDate),
            [nameof(StudentInput.City)] = ValidateCity(student.City),
            [nameof(StudentInput.PostalCode)] = ValidatePostalCode(student.PostalCode),
            [nameof(StudentInput.Street)] = ValidateStreet(student.Street)
        };

        return errors.Where(error => error.Value is not null)
            .OfType<KeyValuePair<string, string>>()
            .ToDictionary(error => error.Key, error => error.Value);
    }

    private static string? ValidateFirstName(string name) => name switch
    {
        _ when !ValidateLength(name, 1, 32) => "Imię musi zawierać od 1 do 32 znaków.",
        _ when !ValidateOnlyLetters(name) => "Imię może zawierać wyłącznie litery.",
        _ => null,
    };

    private static string? ValidateLastName(string name) => name switch
    {
        _ when !ValidateLength(name, 1, 64) => "Nazwisko musi zawierać od 1 do 64 znaków.",
        _ when !ValidateLettersAndSpaces(name) => "Nazwisko może zawierać wyłącznie litery oddzielone spacjami.",
        _ => null,
    };

    private static string? ValidateBirthDate(DateTime date) => date switch
    {
        _ when date > DateTime.Now => "Data urodzenia nie może leżeć w przyszłości.",
        _ => null
    };

    private static string? ValidateCity(string name) => name switch
    {
        _ when !ValidateLength(name, 1, 64) => "Nazwa miasta musi zawierać od 1 do 64 znaków.",
        _ when !ValidateLettersAndSpaces(name) => "Nazwa miasta może zawierać wyłącznie litery oddzielone spacjami.",
        _ => null,
    };

    private static string? ValidatePostalCode(string code) => code switch
    {
        _ when !PostalCodeRegex().IsMatch(code) => "Kod pocztowy musi składać się z pięciu cyfr.",
        _ => null,
    };

    private static string? ValidateStreet(string name) => name switch
    {
        _ when !ValidateLength(name, 1, 80) => "Nazwa ulicy musi zawierać od 1 do 80 znaków.",
        _ when !ValidateLettersAndSpaces(name) => "Nazwa ulicy może zawierać wyłącznie litery oddzielone spacjami.",
        _ => null,
    };

    private static bool ValidateLength(string value, int min, int max)
    {
        return min <= value.Length && value.Length <= max;
    }

    private static bool ValidateOnlyLetters(string value)
    {
        return value.All(char.IsLetter);
    }
    private static bool ValidateLettersAndSpaces(string value)
    {
        return value.All(letter => char.IsLetter(letter) || letter == ' ');
    }
}
