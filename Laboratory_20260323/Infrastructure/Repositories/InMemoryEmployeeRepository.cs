using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Infrastructure.Repositories;

internal class InMemoryEmployeeRepository : IEmployeeRepository
{
    private readonly Dictionary<Guid, Employee> _employees = [];

    public void Insert(Employee employee)
    {
        if (_employees.ContainsKey(employee.Id))
        {
            throw new ArgumentException("Employee already exists.", nameof(employee));
        }
        _employees[employee.Id] = employee;
    }

    public IEnumerable<Employee> GetAll()
    {
        return _employees.Values;
    }

    public Employee? GetById(Guid employeeId)
    {
        _ = _employees.TryGetValue(employeeId, out Employee? employee);
        return employee;
    }

    public void Update(Employee employee)
    {
        if (!_employees.ContainsKey(employee.Id))
        {
            throw new ArgumentException("Employee does not exist.", nameof(employee));
        }
        _employees[employee.Id] = employee;
    }

    public void DeleteById(Guid employeeId)
    {
        _ = _employees.Remove(employeeId);
    }
}
