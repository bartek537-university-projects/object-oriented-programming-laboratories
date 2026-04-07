using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Faculties;
using Laboratory_20260323.Domain.Entities;
using Laboratory_20260323.Presentation.Faculties.Interfaces;

namespace Laboratory_20260323.Presentation.Faculties;

public class FacultyListPresenter : IFacultyListPresenter
{
    private readonly IFacultyListView _view;
    private readonly IWindowService _windows;

    private readonly IRequestHandler<GetFaculties.Query, GetFaculties.Response> _getFacultiesHandler;
    private readonly IRequestHandler<DeleteFaculty.Command, DeleteFaculty.Response> _deleteFacultyHandler;

    public FacultyListPresenter(IFacultyListView view, IWindowService windows,
        IRequestHandler<GetFaculties.Query, GetFaculties.Response> getFacultiesHandler,
        IRequestHandler<DeleteFaculty.Command, DeleteFaculty.Response> deleteFacultyHandler)
    {
        _view = view;
        _windows = windows;

        _getFacultiesHandler = getFacultiesHandler;
        _deleteFacultyHandler = deleteFacultyHandler;

        _view.AddFacultyClicked += OnAddFacultyClicked;
        _view.EditFacultyClicked += OnEditFacultyClicked;
        _view.RemoveFacultyClicked += OnRemoveFacultyClicked;

        UpdateFacultyList();
    }

    private void OnAddFacultyClicked(object? sender, EventArgs e)
    {
        _windows.ShowAddFacultyDialog();
        UpdateFacultyList();
    }

    private void OnEditFacultyClicked(object? sender, Faculty faculty)
    {
        _windows.ShowEditFacultyDialog(faculty);
        UpdateFacultyList();
    }

    private void OnRemoveFacultyClicked(object? sender, Faculty faculty)
    {
        _ = _deleteFacultyHandler.Handle(new(faculty.Id));
        UpdateFacultyList();
    }

    private void UpdateFacultyList()
    {
        IReadOnlyList<Faculty> faculties = GetAllFaculties();
        _view.SetFaculties(faculties);
    }

    private IReadOnlyList<Faculty> GetAllFaculties()
    {
        return _getFacultiesHandler.Handle(new GetFaculties.Query()).Faculties;
    }
}
