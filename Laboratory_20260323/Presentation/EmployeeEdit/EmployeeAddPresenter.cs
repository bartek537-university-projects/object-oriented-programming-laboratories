using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Application.Employees;
using Laboratory_20260323.Presentation.EmployeeEdit.Interfaces;

namespace Laboratory_20260323.Presentation.EmployeeEdit;

public class EmployeeAddPresenter : IEmployeeEditPresenter
{
    private readonly IEmployeeEditView _view;
    private readonly IAddEmployeeHandler _addEmployeeHandler;

    public EmployeeAddPresenter(IEmployeeEditView view, IAddEmployeeHandler addEmployeeHandler)
    {
        _view = view;
        _addEmployeeHandler = addEmployeeHandler;

        _view.SubmitClicked += OnSubmitClicked;
        _view.CancelClicked += OnCancelClicked;
    }

    private void OnSubmitClicked(object? sender, EventArgs e)
    {
        _view.SetErrors(null);

        var firstName = _view.FirstName.Trim();
        var lastName = _view.LastName.Trim();

        AddEmployee.Request request = new(firstName, lastName);

        try
        {
            AddEmployee.Response _ = _addEmployeeHandler.Handle(request);
            _view.Close();
        }
        catch(ValidationException ex)
        {
            _view.SetErrors(ex.Errors);
        }
    }

    private void OnCancelClicked(object? sender, EventArgs e)
    {
        _view.Close();
    }
}
