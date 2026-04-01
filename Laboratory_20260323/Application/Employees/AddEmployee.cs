using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Application.Employees.Interfaces;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Employees;

public class AddEmployee
{
    public record Request(string FirstName, string LastName) : IEmployeeData;

    public class Handler(IValidator<IEmployeeData> validator, IEmployeeRepository repository) : IAddEmployeeHandler
    {
        public Response Handle(Request request)
        {
            var errors = validator.Validate(request);

            if (errors.Count > 0)
            {
                throw new ValidationException(errors);
            }

            Employee employee = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
            };

            repository.Insert(employee);

            return new Response();
        }
    }

    public record Response();
}

public interface IAddEmployeeHandler
{
    AddEmployee.Response Handle(AddEmployee.Request request);
}
