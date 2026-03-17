using Laboratory_20260309.Domain.Models;
using Laboratory_20260309.Presentation.StudentForm.Interfaces;

namespace Laboratory_20260309.Presentation.StudentForm;

internal class StudentFormPresenter : IStudentFormPresenter
{
    private readonly IStudentFormView _view;
    private readonly StudentRegister _studentRegister = new();

    private Student? _selectedStudent = null;

    public StudentFormPresenter(IStudentFormView view)
    {
        _view = view;
        _view.SetStudents(_studentRegister.Students);

        _view.SaveStudentClicked += OnSaveStudentClicked;
        _view.EditStudentClicked += OnEditStudentClicked;
        _view.DeleteStudentClicked += OnDeleteStudentClicked;

        _view.StudentSelected += OnStudentSelected;
    }

    private void OnSaveStudentClicked(object? sender, StudentInput input)
    {
        var errors = input.Validate();
        _view.SetFormErorrs(errors);

        if (errors.Count > 0)
        {
            return;
        }

        var student = input.ToStudent();
        _studentRegister.Upsert(student);

        _view.ClearForm();
    }

    private void OnEditStudentClicked(object? sender, StudentInput input)
    {
        if (_selectedStudent is not { } selection)
        {
            return;
        }

        var errors = input.Validate();
        _view.SetFormErorrs(errors);

        if(errors.Count > 0)
        {
            return;
        }

        var student = input.ToStudent(id: selection.Id);
        _studentRegister.Upsert(student);

        _view.ClearForm();
    }

    private void OnDeleteStudentClicked(object? sender, EventArgs e)
    {
        if (_selectedStudent is not { } selection)
        {
            return;
        }

        _studentRegister.Delete(selection);

        _view.ClearForm();
    }


    private void OnStudentSelected(object? sender, Student? student)
    {
        _selectedStudent = student;

        if (student is null)
        {
            _view.ClearForm();
        }
        else
        {
            _view.PopulateForm(student);
        }
    }
}
