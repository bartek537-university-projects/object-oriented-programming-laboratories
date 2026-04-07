using Laboratory_20260323.Application.Persistence.Mappers;

namespace Laboratory_20260323.Application.Abstractions.Repositories;

public interface IApplicationSnapshotRepository
{
    void Save(ApplicationDataSnapshot snapshot, string path);
    ApplicationDataSnapshot Load(string path);
}
