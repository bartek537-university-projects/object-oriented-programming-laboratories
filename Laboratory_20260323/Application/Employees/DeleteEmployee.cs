using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Employees;

public class DeleteEmployee
{
    public record Command(Guid EmployeeId) : IRequest<Response>;

    public class Handler(IEmployeeRepository repository)
        : IRequestHandler<Command, Response>
    {
        public Response Handle(Command command)
        {
            Employee employee = GetEmployeeOrThrow(command.EmployeeId);
            // TODO: Add check for related data (reservations).

            repository.DeleteById(employee.Id);

            return new Response();
        }

        private Employee GetEmployeeOrThrow(Guid employeeId)
        {
            return repository.GetById(employeeId) ?? throw new NotFoundException("Employee does not exist.");
        }
    }

    public record Response();
}