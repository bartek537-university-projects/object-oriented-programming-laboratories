using Laboratory_20260309.Domain.Models;
using System.ComponentModel;

namespace Laboratory_20260309.Presentation.StudentForm;

internal class StudentRegister
{
    public BindingList<Student> Students { get; } = [];

    public void Add(Student student)
    {
        if (Students.Contains(student))
        {
            return;
        }
        Students.Add(student);
    }

    public void Delete(Student student)
    {
        Students.Remove(student);
    }
}
