using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Abstractions.Repositories;

public interface IEmployeeRepository
{
    void ReplaceAll(IReadOnlyList<Employee> employees);

    void Insert(Employee employee);

    IEnumerable<Employee> GetAll();
    Employee? GetById(Guid employeeId);

    bool ExistsById(Guid employeeId);

    void Update(Employee employee);

    void DeleteById(Guid employeeId);
}
