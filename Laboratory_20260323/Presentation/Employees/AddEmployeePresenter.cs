using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Application.Employees;
using Laboratory_20260323.Presentation.Employees.Interfaces;

namespace Laboratory_20260323.Presentation.Employees;

public class AddEmployeePresenter : IManageEmployeePresenter
{
    private readonly IManageEmployeeView _view;
    private readonly IRequestHandler<AddEmployee.Command, AddEmployee.Response> _addEmployeeHandler;

    public AddEmployeePresenter(IManageEmployeeView view,
        IRequestHandler<AddEmployee.Command, AddEmployee.Response> addEmployeeHandler)
    {
        _view = view;
        _addEmployeeHandler = addEmployeeHandler;

        _view.SubmitClicked += OnSubmitClicked;
        _view.CancelClicked += OnCancelClicked;
    }

    private void OnSubmitClicked(object? sender, EventArgs e)
    {
        _view.SetErrors(null);

        string firstName = _view.FirstName.Trim();
        string lastName = _view.LastName.Trim();

        AddEmployee.Command command = new(firstName, lastName);

        try
        {
            AddEmployee.Response _ = _addEmployeeHandler.Handle(command);
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
