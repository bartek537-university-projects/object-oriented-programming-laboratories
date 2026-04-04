using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Application.Faculties;
using Laboratory_20260323.Presentation.Faculties.Interfaces;

namespace Laboratory_20260323.Presentation.Faculties;

public class AddFacultyPresenter : IManageFacultyPresenter
{
    private readonly IManageFacultyView _view;
    private readonly IAddFacultyHandler _addFacultyHandler;

    public AddFacultyPresenter(IManageFacultyView view, IAddFacultyHandler addFacultyHandler)
    {
        _view = view;
        _addFacultyHandler = addFacultyHandler;

        _view.SubmitClicked += OnSubmitClicked;
        _view.CancelClicked += OnCancelClicked;
    }

    private void OnSubmitClicked(object? sender, EventArgs e)
    {
        _view.SetErrors(null);

        string facultyName = _view.FacultyName;
        string city = _view.City;
        string postalCode = _view.PostalCode;
        string street = _view.Street;
        string building = _view.Building;

        AddFaculty.Command command = new(facultyName, city, postalCode, street, building);

        try
        {
            AddFaculty.Response _ = _addFacultyHandler.Handle(command);
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
