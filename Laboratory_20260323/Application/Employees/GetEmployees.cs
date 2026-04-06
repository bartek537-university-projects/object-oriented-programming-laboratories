using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Employees;

public class GetEmployees
{
    public record Query() : IRequest<Response>;

    public class Handler(IEmployeeRepository repository)
        : IRequestHandler<Query, Response>
    {
        public Response Handle(Query query)
        {
            List<Employee> employees = [.. repository.GetAll()];
            return new Response(employees);
        }
    }

    public record Response(IReadOnlyList<Employee> Employees);
}