using Laboratory_20260309.Domain.Models;
using System.ComponentModel;

namespace Laboratory_20260309.Presentation.StudentForm;

internal class DziennikStudentow
{
    public BindingList<Student> Students { get; } = [];

    public void Upsert(Student student)
    {
        _ = Students.Remove(student);
        Students.Add(student);
    }

    public void Delete(Student student)
    {
        _ = Students.Remove(student);
    }
}
