using Laboratory_20260309.Domain.Models;
using System.Text.Json;

namespace Laboratory_20260309.Data.Helpers;

internal static class StudentJsonHelper
{
    public static void SaveStudents(IEnumerable<Student> students, string path)
    {
        var json = JsonSerializer.Serialize(students);
        File.WriteAllText(path, json);
    }

    public static IEnumerable<Student> ReadStudents(string path)
    {
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<IEnumerable<Student>>(json) ?? [];
    }
}