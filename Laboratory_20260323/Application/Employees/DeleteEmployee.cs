using Laboratory_20260323.Application.Abstractions.Repositories;

namespace Laboratory_20260323.Application.Employees;

public class DeleteEmployee
{
    public record Command(Guid EmployeeId);

    public class Handler(IEmployeeRepository repository)
        : IDeleteEmployeeHandler
    {
        public Response Handle(Command command)
        {
            ValidateEmployeeExists(command.EmployeeId);
            // TODO: Add check for related data (reservations).

            repository.DeleteById(command.EmployeeId);

            return new Response();
        }

        private void ValidateEmployeeExists(Guid employeeId)
        {
            if (!repository.ExistsById(employeeId))
            {
                throw new ArgumentException("Employee does not exist.", nameof(employeeId));
            }
        }
    }

    public record Response();
}

public interface IDeleteEmployeeHandler
{
    DeleteEmployee.Response Handle(DeleteEmployee.Command request);
}

