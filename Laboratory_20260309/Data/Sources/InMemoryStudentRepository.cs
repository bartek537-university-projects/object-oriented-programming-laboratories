using Laboratory_20260309.Data.Helpers;
using Laboratory_20260309.Domain.Models;
using Laboratory_20260309.Domain.Repositories;

namespace Laboratory_20260309.Data.Sources;

internal class InMemoryStudentRepository : IStudentRepository
{
    public void Save(IEnumerable<Student> students, string path)
    {
        StudentJsonHelper.SaveStudents(students, path);
    }

    public IEnumerable<Student> Read(string path)
    {
        return StudentJsonHelper.ReadStudents(path);
    }
}
