using Laboratory_20260309.Domain.Models;
using System.Text.Json;

namespace Laboratory_20260309;

internal class StudentJsonHelper
{
    public void SaveStudents(IEnumerable<Student> students, string fileName)
    {
        var json = JsonSerializer.Serialize(students);
        File.WriteAllText(fileName, json);
    }

    public IEnumerable<Student> ReadStudents(string fileName)
    {
        var json = File.ReadAllText(fileName);
        return JsonSerializer.Deserialize<IEnumerable<Student>>(json) ?? [];
    }
}