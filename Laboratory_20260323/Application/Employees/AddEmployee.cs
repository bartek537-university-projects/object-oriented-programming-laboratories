using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Employees;

public class AddEmployee
{
    public record Command(string FirstName, string LastName) : IRequest<Response>;

    public class Handler(IValidator<Command> validator, IEmployeeRepository repository)
        : IRequestHandler<Command, Response>
    {
        public Response Handle(Command command)
        {
            ValidateRequest(command);

            Employee employee = new()
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
            };

            repository.Insert(employee);

            return new Response();
        }

        private void ValidateRequest(Command command)
        {
            if (validator.Validate(command) is { Count: > 0 } errors)
            {
                throw new ValidationException(errors);
            }
        }
    }

    public record Response();
}
