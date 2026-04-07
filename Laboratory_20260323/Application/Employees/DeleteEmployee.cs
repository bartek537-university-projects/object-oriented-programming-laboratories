using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Employees;

public class DeleteEmployee
{
    public record Command(Guid EmployeeId) : IRequest<Response>;

    public class Handler(IEmployeeRepository employeeRepository, IReservationRepository reservationRepository)
        : IRequestHandler<Command, Response>
    {
        public Response Handle(Command command)
        {
            Employee employee = GetEmployeeOrThrow(command.EmployeeId);

            EnsureHasNoActiveDependencies(employee);

            employeeRepository.DeleteById(employee.Id);

            return new Response();
        }

        private Employee GetEmployeeOrThrow(Guid employeeId)
        {
            return employeeRepository.GetById(employeeId) ?? throw new NotFoundException("Employee does not exist.");
        }

        private void EnsureHasNoActiveDependencies(Employee employee)
        {
            if (CheckHasLinkedReservations(employee))
            {
                throw new ConflictException("Employee has linked reservations.");
            }
        }

        private bool CheckHasLinkedReservations(Employee employee)
        {
            return reservationRepository.ExistsByEmployeeId(employee.Id);
        }
    }

    public record Response();
}