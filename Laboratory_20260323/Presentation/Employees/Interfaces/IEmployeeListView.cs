using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Presentation.Employees.Interfaces;

public interface IEmployeeListView
{
    event EventHandler AddEmployeeClicked;
    event EventHandler<Employee> EditEmployeeClicked;
    event EventHandler<Employee> RemoveEmployeeClicked;

    void SetEmployees(IReadOnlyList<Employee> employees);
    void ShowError(string message);
}
