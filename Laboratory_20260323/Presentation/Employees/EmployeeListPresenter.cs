using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Application.Employees;
using Laboratory_20260323.Domain.Entities;
using Laboratory_20260323.Presentation.Employees.Interfaces;

namespace Laboratory_20260323.Presentation.Employees;

public class EmployeeListPresenter : IEmployeeListPresenter
{
    private readonly IEmployeeListView _view;
    private readonly IWindowService _windows;

    private readonly IRequestHandler<GetEmployees.Query, GetEmployees.Response> _getEmployeesHandler;
    private readonly IRequestHandler<DeleteEmployee.Command, DeleteEmployee.Response> _deleteEmployeeHandler;

    public EmployeeListPresenter(IEmployeeListView view, IWindowService windows,
        IRequestHandler<GetEmployees.Query, GetEmployees.Response> getEmployeesHandler,
        IRequestHandler<DeleteEmployee.Command, DeleteEmployee.Response> deleteEmployeeHandler)
    {
        _view = view;
        _windows = windows;

        _getEmployeesHandler = getEmployeesHandler;
        _deleteEmployeeHandler = deleteEmployeeHandler;

        _view.AddEmployeeClicked += OnAddEmployeeClicked;
        _view.EditEmployeeClicked += OnEditEmployeeClicked;
        _view.RemoveEmployeeClicked += OnRemoveEmployeeClicked;

        UpdateEmployeeList();
    }

    private void OnAddEmployeeClicked(object? sender, EventArgs e)
    {
        _windows.ShowAddEmployeeDialog();
        UpdateEmployeeList();
    }

    private void OnEditEmployeeClicked(object? sender, Employee employee)
    {
        _windows.ShowEditEmployeeDialog(employee);
        UpdateEmployeeList();
    }

    private void OnRemoveEmployeeClicked(object? sender, Employee employee)
    {
        try
        {
            _ = _deleteEmployeeHandler.Handle(new(employee.Id));
            UpdateEmployeeList();
        }
        catch (ConflictException ex)
        {
            _view.ShowError(ex.Message);
        }
    }

    private void UpdateEmployeeList()
    {
        IReadOnlyList<Employee> employees = GetAllEmployees();
        _view.SetEmployees(employees);
    }

    private IReadOnlyList<Employee> GetAllEmployees()
    {
        return _getEmployeesHandler.Handle(new GetEmployees.Query()).Employees;
    }
}
