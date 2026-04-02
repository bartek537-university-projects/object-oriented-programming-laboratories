using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Application.Employees;
using Laboratory_20260323.Domain.Entities;
using Laboratory_20260323.Presentation.Employees.Interfaces;

namespace Laboratory_20260323.Presentation.Employees;

public class EditEmployeePresenter : IManageEmployeePresenter
{
    private readonly IManageEmployeeView _view;
    private readonly IUpdateEmployeeHandler _updateEmployeeHandler;

    private readonly Employee _employee;

    public EditEmployeePresenter(Employee employee, IManageEmployeeView view, IUpdateEmployeeHandler updateEmployeeHandler)
    {
        _view = view;
        _updateEmployeeHandler = updateEmployeeHandler;
        _employee = employee;

        LoadEmployeeIntoView();

        _view.SubmitClicked += OnSubmitClicked;
        _view.CancelClicked += OnCancelClicked;
    }

    private void LoadEmployeeIntoView()
    {
        _view.Identifier = _employee.Id.ToString();
        _view.FirstName = _employee.FirstName;
        _view.LastName = _employee.LastName;
    }

    private void OnSubmitClicked(object? sender, EventArgs e)
    {
        _view.SetErrors(null);

        string firstName = _view.FirstName.Trim();
        string lastName = _view.LastName.Trim();

        UpdateEmployee.Command request = new(_employee.Id, firstName, lastName);

        try
        {
            UpdateEmployee.Response _ = _updateEmployeeHandler.Handle(request);
            _view.Close();
        }
        catch (ValidationException ex)
        {
            _view.SetErrors(ex.Errors);
        }
    }

    private void OnCancelClicked(object? sender, EventArgs e)
    {
        _view.Close();
    }

}
