using Laboratory_20260309.Domain.Models;
using Laboratory_20260309.Presentation.StudentForm.Interfaces;

namespace Laboratory_20260309.Presentation.StudentForm;

internal class StudentFormPresenter : IStudentFormPresenter
{
    private readonly IStudentFormView _view;
    private readonly StudentRegister _studentRegister = new();

    public StudentFormPresenter(IStudentFormView view)
    {
        _view = view;
        _view.SetStudents(_studentRegister.Students);

        _view.SaveStudentClicked += OnSaveStudentClicked;
        _view.StudentSelected += OnStudentSelected;
    }

    private void OnSaveStudentClicked(object? sender, EventArgs e)
    {
        var student = _view.GetStudent();

        var errors = student.Validate();
        _view.SetErrors(errors);

        if (errors.Count > 0)
        {
            return;
        }

        AddStudent(student);
        _view.ClearForm();
    }

    private void AddStudent(StudentFormDto model)
    {
        var student = model.ToStudent();
        _studentRegister.Add(student);
    }

    private void OnStudentSelected(object? sender, Student? student)
    {
        if (student is null)
        {
            _view.ClearForm();
        }
        else
        {
            _view.LoadStudent(student);
        }
    }
}
