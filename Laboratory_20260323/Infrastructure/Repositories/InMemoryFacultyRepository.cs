using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Infrastructure.Repositories;

public class InMemoryFacultyRepository : IFacultyRepository
{
    private readonly Dictionary<Guid, Faculty> _faculties = [];

    public void Insert(Faculty faculty)
    {
        if (_faculties.ContainsKey(faculty.Id))
        {
            throw new ArgumentException("Faculty already exists.", nameof(faculty));
        }
        _faculties[faculty.Id] = faculty;
    }

    public IEnumerable<Faculty> GetAll()
    {
        return _faculties.Values;
    }

    public Faculty? GetById(Guid facultyId)
    {
        _ = _faculties.TryGetValue(facultyId, out Faculty? faculty);
        return faculty;
    }

    public bool ExistsById(Guid facultyId)
    {
        return _faculties.ContainsKey(facultyId);
    }

    public void Update(Faculty faculty)
    {
        if (!_faculties.ContainsKey(faculty.Id))
        {
            throw new ArgumentException("Faculty does not exist.", nameof(faculty));
        }
        _faculties[faculty.Id] = faculty;
    }

    public void DeleteById(Guid facultyId)
    {
        _ = _faculties.Remove(facultyId);
    }
}
