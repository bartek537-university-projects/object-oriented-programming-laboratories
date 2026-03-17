using Laboratory_20260309.Domain.Models;

namespace Laboratory_20260309.Presentation.StudentForm.Interfaces;

internal interface IStudentFormView
{
    void SetFormErorrs(Dictionary<string, string> errors);
    void PopulateForm(Student student);
    void ClearForm();

    event EventHandler<StudentInput> SaveStudentClicked;
    event EventHandler<StudentInput> EditStudentClicked;
    event EventHandler DeleteStudentClicked;

    void SetStudents(IReadOnlyList<Student> students);

    event EventHandler<Student?> StudentSelected;
}
