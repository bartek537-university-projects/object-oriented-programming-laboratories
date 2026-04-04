using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Application.Abstractions.Repositories;

public interface IFacultyRepository
{
    void Insert(Faculty faculty);

    IEnumerable<Faculty> GetAll();
    Faculty? GetById(Guid facultyId);

    bool ExistsById(Guid facultyId);

    void Update(Faculty faculty);

    void DeleteById(Guid facultyId);
}
