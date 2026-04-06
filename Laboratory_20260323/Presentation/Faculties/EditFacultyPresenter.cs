using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Common.Exceptions;
using Laboratory_20260323.Application.Faculties;
using Laboratory_20260323.Domain.Entities;
using Laboratory_20260323.Presentation.Faculties.Interfaces;

public class EditFacultyPresenter : IManageFacultyPresenter
{
    private readonly IManageFacultyView _view;
    private readonly IRequestHandler<UpdateFaculty.Command, UpdateFaculty.Response> _updateFacultyHandler;

    private readonly Faculty _faculty;

    public EditFacultyPresenter(Faculty faculty, IManageFacultyView view,
        IRequestHandler<UpdateFaculty.Command, UpdateFaculty.Response> updateFacultyHandler)
    {
        _faculty = faculty;

        _view = view;
        _updateFacultyHandler = updateFacultyHandler;

        LoadFacultyIntoView();

        _view.SubmitClicked += OnSubmitClicked;
        _view.CancelClicked += OnCancelClicked;
    }

    private void LoadFacultyIntoView()
    {
        _view.Identifier = _faculty.Id.ToString();
        _view.FacultyName = _faculty.Name;
        _view.City = _faculty.Address.City;
        _view.Street = _faculty.Address.Street;
        _view.PostalCode = _faculty.Address.PostalCode;
        _view.Building = _faculty.Address.Building;
    }

    private void OnSubmitClicked(object? sender, EventArgs e)
    {
        _view.SetErrors(null);

        string facultyName = _view.FacultyName;
        string city = _view.City;
        string postalCode = _view.PostalCode;
        string street = _view.Street;
        string building = _view.Building;

        UpdateFaculty.Command command = new(_faculty.Id, facultyName, city, postalCode, street, building);

        try
        {
            UpdateFaculty.Response _ = _updateFacultyHandler.Handle(command);
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
