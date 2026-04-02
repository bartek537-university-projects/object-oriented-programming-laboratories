using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Application.Employees.Interfaces;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Employees;

public class UpdateEmployee
{
    public record Command(Guid EmployeeId, string FirstName, string LastName) : IEmployeeData;

    public class Handler(IValidator<IEmployeeData> validator, IEmployeeRepository repository)
        : IUpdateEmployeeHandler
    {
        public Response Handle(Command command)
        {
            ValidateEmployeeDetails(command);
            ValidateEmployeeExists(command.EmployeeId);

            Employee employee = CreateEmployee(command);
            repository.Update(employee);

            return new Response();
        }

        private void ValidateEmployeeDetails(Command command)
        {
            Dictionary<string, string> errors = validator
                .Validate(command);

            if (errors.Count > 0)
            {
                throw new ValidationException(errors);
            }
        }

        private void ValidateEmployeeExists(Guid employeeId)
        {
            if (repository.GetById(employeeId) is null)
            {
                throw new ArgumentException("Employee does not exist.", nameof(employeeId));
            }
        }

        private static Employee CreateEmployee(Command command)
        {
            return new()
            {
                Id = command.EmployeeId,
                FirstName = command.FirstName,
                LastName = command.LastName,
            };
        }
    }

    public record Response();
}

public interface IUpdateEmployeeHandler
{
    UpdateEmployee.Response Handle(UpdateEmployee.Command request);
}
