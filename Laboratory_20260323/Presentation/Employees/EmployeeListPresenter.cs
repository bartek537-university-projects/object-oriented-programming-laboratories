using Laboratory_20260323.Application.Employees;
using Laboratory_20260323.Domain.Entities;
using Laboratory_20260323.Presentation.Employees.Interfaces;

namespace Laboratory_20260323.Presentation.Employees;

public class EmployeeListPresenter : IEmployeeListPresenter
{
    private readonly IEmployeeListView _view;
    private readonly IWindowService _windowService;

    private readonly IGetEmployeesHandler _getEmployeesHandler;
    private readonly IDeleteEmployeeHandler _deleteEmployeeHandler;

    public EmployeeListPresenter(IEmployeeListView view, IWindowService windowService,
        IGetEmployeesHandler getEmployeesHandler, IDeleteEmployeeHandler deleteEmployeeHandler)
    {
        _view = view;
        _windowService = windowService;

        _getEmployeesHandler = getEmployeesHandler;
        _deleteEmployeeHandler = deleteEmployeeHandler;

        _view.AddEmployeeClicked += OnAddEmployeeClicked;
        _view.EditEmployeeClicked += OnEditEmployeeClicked;
        _view.RemoveEmployeeClicked += OnRemoveEmployeeClicked;
    }

    private void OnAddEmployeeClicked(object? sender, EventArgs e)
    {
        _windowService.ShowAddEmployeeDialog();
        UpdateEmployeeList();
    }

    private void OnEditEmployeeClicked(object? sender, Employee employee)
    {
        _windowService.ShowEditEmployeeDialog(employee);
        UpdateEmployeeList();
    }

    private void OnRemoveEmployeeClicked(object? sender, Employee employee)
    {
        _ = _deleteEmployeeHandler.Handle(new(employee.Id));
        UpdateEmployeeList();
    }

    private void UpdateEmployeeList()
    {
        var employees = GetAllEmployees();
        _view.SetEmployees(employees);
    }

    private IReadOnlyList<Employee> GetAllEmployees()
    {
        return _getEmployeesHandler.Handle(new GetEmployees.Query()).Employees;
    }
}
