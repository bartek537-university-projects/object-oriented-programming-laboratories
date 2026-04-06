using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Employees;

public class UpdateEmployee
{
    public record Command(Guid EmployeeId, string FirstName, string LastName) : IRequest<Response>;

    public class Handler(IValidator<Command> validator, IEmployeeRepository repository)
        : IRequestHandler<Command, Response>
    {
        public Response Handle(Command command)
        {
            ValidateRequest(command);

            Employee oldEmployee = GetEmployeeOrThrow(command.EmployeeId);

            Employee newEmployee = new()
            {
                Id = oldEmployee.Id,
                FirstName = command.FirstName,
                LastName = command.LastName,
            };

            repository.Update(newEmployee);

            return new Response();
        }

        private void ValidateRequest(Command command)
        {
            if (validator.Validate(command) is { Count: > 0 } errors)
            {
                throw new ValidationException(errors);
            }
        }

        private Employee GetEmployeeOrThrow(Guid employeeId)
        {
            return repository.GetById(employeeId) ?? throw new NotFoundException("Employee does not exist.");
        }
    }

    public record Response();
}