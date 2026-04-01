using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Employees.Interfaces;
using Laboratory_20260323.Domain.Entities;
using System.Text.RegularExpressions;

namespace Laboratory_20260323.Application.Employees.Validators;

public partial class EmployeeDataValidator : IValidator<IEmployeeData>
{
    [GeneratedRegex(@"^[A-Za-z]{2,16}$", RegexOptions.Singleline)]
    private static partial Regex FirstNameRegex();
    [GeneratedRegex(@"^[A-Za-z-]{1,32}$", RegexOptions.Singleline)]
    private static partial Regex LastNameRegex();

    public Dictionary<string, string> Validate(IEmployeeData employee)
    {
        Dictionary<string, (bool IsValid, string Message)> errors = new()
        {
            [nameof(Employee.FirstName)] = ValidateFirstName(employee.FirstName),
            [nameof(Employee.LastName)] = ValidateLastName(employee.LastName),
        };

        return errors.Where(error => !error.Value.IsValid)
            .ToDictionary(error => error.Key, error => error.Value.Message);
    }

    private static (bool, string) ValidateFirstName(string name)
    {
        if (FirstNameRegex().IsMatch(name))
        {
            return (true, string.Empty);
        }
        return (false, "First name must contain between 2 and 16 letters.");
    }

    private static (bool, string) ValidateLastName(string name)
    {
        if (LastNameRegex().IsMatch(name))
        {
            return (true, string.Empty);
        }
        return (false, "First name must contain between 1 and 32 letters and dashes.");
    }
}