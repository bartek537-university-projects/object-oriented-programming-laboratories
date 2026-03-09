using Laboratory_20260309.Domain.Models;
using System.ComponentModel;

namespace Laboratory_20260309.Domain;

internal class StudentRegister
{
    public BindingList<Student> Students { get; } = [];

    public void AddStudent(Student student)
    {
        if (Students.Contains(student))
        {
            return;
        }
        Students.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        Students.Remove(student);
    }
}
