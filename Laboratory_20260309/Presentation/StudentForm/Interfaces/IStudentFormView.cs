namespace Laboratory_20260309.Presentation.StudentForm.Interfaces;

internal interface IStudentFormView
{
    StudentFormDto GetStudent();

    void SetErrors(Dictionary<string, string> errors);
    void ClearForm();

    event EventHandler SaveStudentClicked;
}
