using Laboratory_20260309.Domain.Models;

namespace Laboratory_20260309.Presentation.StudentForm.Interfaces;

internal interface IStudentFormView
{
    StudentFormDto GetStudent();

    void SetErrors(Dictionary<string, string> errors);
    void ClearForm();

    void LoadStudent(Student student);
    void SetStudents(IReadOnlyList<Student> students);

    event EventHandler SaveStudentClicked;
    event EventHandler<Student?> StudentSelected;
}
