using Laboratory_20260309.Domain.Models;

namespace Laboratory_20260309.Domain.Repositories;

internal interface IStudentRepository
{
    IEnumerable<Student> Read(string path);
    void Save(IEnumerable<Student> students, string path);
}
