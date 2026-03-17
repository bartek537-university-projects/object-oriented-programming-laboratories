using Laboratory_20260309.Presentation.StudentForm.Interfaces;

namespace Laboratory_20260309.Presentation.StudentForm;

internal class StudentFormPresenter : IStudentFormPresenter
{
    private readonly IStudentFormView _view;

    public StudentFormPresenter(IStudentFormView view)
    {
        _view = view;

        _view.SaveStudentClicked += OnSaveStudentClicked;
    }

    private void OnSaveStudentClicked(object? sender, EventArgs e)
    {
        var model = _view.GetStudent();

        var errors = model.Validate();
        _view.SetErrors(errors);

        if (errors.Count > 0)
        {
            return;
        }

        var student = model.ToStudent();

        Console.WriteLine($"student {student.FirstName} is ready.");

        // TODO: Save the user.
        _view.ClearForm();
    }
}
