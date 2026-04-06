using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Domain.Entities;
using System.Text.RegularExpressions;

namespace Laboratory_20260323.Application.Employees.Validators;

public partial class EmployeeValidator : IValidator<AddEmployee.Command>, IValidator<UpdateEmployee.Command>
{
    [GeneratedRegex(@"^[A-Za-z]{2,16}$", RegexOptions.Singleline)]
    private static partial Regex FirstNameRegex();
    [GeneratedRegex(@"^[A-Za-z-]{1,32}$", RegexOptions.Singleline)]
    private static partial Regex LastNameRegex();

    public Dictionary<string, string> Validate(AddEmployee.Command ac)
    {
        return Validate(new EmployeeDetails(ac.FirstName, ac.LastName));
    }

    public Dictionary<string, string> Validate(UpdateEmployee.Command uc)
    {
        return Validate(new EmployeeDetails(uc.FirstName, uc.LastName));
    }

    private static Dictionary<string, string> Validate(EmployeeDetails employee)
    {
        IReadOnlyList<(string Field, string? Message)> errors = [
            (nameof(Employee.FirstName), ValidateFirstName(employee.FirstName)),
            (nameof(Employee.LastName), ValidateLastName(employee.LastName)),
        ];

        return errors.Where(error => error.Message is not null)
            .ToDictionary(error => error.Field, error => error.Message!);
    }

    private static string? ValidateFirstName(string name)
    {
        return !FirstNameRegex().IsMatch(name) ? "First name must contain between 2 and 16 letters." : null;
    }

    private static string? ValidateLastName(string name)
    {
        return !LastNameRegex().IsMatch(name) ? "Last name must contain between 1 and 32 letters and dashes." : null;
    }

    private record EmployeeDetails(string FirstName, string LastName);
}