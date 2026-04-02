using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Employees;

public class GetEmployees
{
    public record Query();

    public class Handler(IEmployeeRepository repository)
        : IGetEmployeesHandler
    {
        public Response Handle(Query query)
        {
            List<Employee> employees = repository.GetAll().ToList();
            return new Response(employees);
        }
    }

    public record Response(IReadOnlyList<Employee> Employees);
}

public interface IGetEmployeesHandler
{
    GetEmployees.Response Handle(GetEmployees.Query query);
}
