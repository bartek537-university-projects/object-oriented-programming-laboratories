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
        AddEmployee.Request request = new(_view.FirstName, _view.LastName);

        AddEmployee.Response _ = _addEmployeeHandler.Handle(request);

        _view.Close();
    }

    private void OnCancelClicked(object? sender, EventArgs e)
    {
        _view.Close();
    }
}
