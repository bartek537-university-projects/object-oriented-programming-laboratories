using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Abstractions.Repositories;

public interface IEmployeeRepository
{
    void Insert(Employee employee);
}
